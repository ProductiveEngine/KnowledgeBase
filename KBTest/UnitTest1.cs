using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.Accessors;
using System.Linq;
using DAL.Models;
using System.Collections.Generic;

namespace KBTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly CategoryAccessor _categoryAccessor;
        
        public UnitTest1()
        {
            _categoryAccessor = new CategoryAccessor();
        }

        [TestMethod]
        public void TestCategories()
        {            
            var categories = _categoryAccessor.Repo.All.ToList();

            CategoryVO cat = new CategoryVO();
            cat.Title = "Databases";
            _categoryAccessor.Repo.InsertOrUpdate(cat);
            _categoryAccessor.Save();

            List<CategoryVO> q = _categoryAccessor.Repo.All.Where(x => x.Title == "Databases").ToList();

            if (q == null || q.Count == 0)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual("Databases", q.First().Title);
            }
        }
    }
}
//public void CanInsertCustomerWithOrderIntoDatabase()
//{
//    string guidStoredInCompanyForTesting = Guid.NewGuid().ToString();
//    ProductReference bikeProduct;
//    using (var refRepo = new ReferenceDataRepository())
//    {
//        bikeProduct = refRepo.Products.FirstOrDefault(p => p.ProductNumber == "BK-R68R-44");
//    }
//    using (var uow = new UnitOfWork<CustomerServiceContext>())
//    {
//        using (var repo = new CustomerRepository(uow))
//        {
//            repo.InsertOrUpdateGraph(new Customer
//            {
//                FirstName = "Julie",
//                LastName = "Lerman",
//                Phone = "802 555 1212",
//                EmailAddress = "julielerman@gmail.com",
//                Addresses = new List<Address> { new Address { Street1 = "Main St", City = "Anytown" } },
//                Title = "Ms.",
//                CompanyName = guidStoredInCompanyForTesting,
//                Orders = new List<Order>
//                                               {
//                                                 new Order
//                                                   {
//                                                     OrderDate = DateTime.Now,
//                                                     DueDate = DateTime.Now.AddDays(7),
//                                                     ModifiedDate = DateTime.Now,
//                                                     LineItems = new List<LineItem>
//                                                                   {
//                                                                     new LineItem
//                                                                       {
//                                                                         OrderQty = 1,
//                                                                         ProductId = bikeProduct.ProductId,
//                                                                         UnitPrice = bikeProduct.ListPrice
//                                                                       }
//                                                                   }
//                                                   }
//                                               }
//            }
//                                    );
//            uow.Save();
//        }
//    }
//    using (var repo = new CustomerRepository(new UnitOfWork<CustomerServiceContext>()))
//    {
//        Assert.IsTrue(repo.All.Any(c => c.CompanyName == guidStoredInCompanyForTesting));
//    }
//}