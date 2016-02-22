using System;
using System.Linq;
using KB.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //DAL
            //var ConnStr = ConfigurationManager.AppSettings["Trackboard"];
            //Title Databases
            //using (var repo = new CategoryRepo(new KBUOW<KBContext>()))
            //{
            //    var a = repo.All.Any(c => c.Title == "Databases");
            //    Assert.IsTrue(repo.All.Any(c => c.Title == "Databases"));
            //}

            CategoryBL cBL = new CategoryBL();
            Assert.IsTrue(cBL.GetAll().Any(c => c.Title == "Databases"));

        }
    }
}

//namespace AutomatedTests
//{
//    [TestClass]
//    public class TestContexts
//    {
//        public TestContexts()
//        {
//            ReCreateCompanyDatabaseForTesting();
//        }

//        public void ReCreateCompanyDatabaseForTesting()
//        {
//            Database.SetInitializer(new DatabaseSeedingInitializer());
//            using (var context = new CompanyDatabase())
//            {
//                context.Database.Initialize(true);
//            }
//        }


//        [TestMethod]
//        public void ValidationCatchesTooLongLastName()
//        {
//            const string fiftyCharString = "12345678901234567890123456789012345678901234567890";
//            Exception exception = null;
//            var customer = new Customer { LastName = fiftyCharString, FirstName = "Julie" };
//            using (var uow = new UnitOfWork<CustomerServiceContext>())
//            {
//                using (var repo = new CustomerRepository(uow))
//                {
//                    repo.InsertOrUpdate(customer);
//                    try
//                    {
//                        uow.Save();
//                        Assert.Fail("Expected Entity Framework Validation exception was not thrown");
//                    }
//                    catch (Exception ex)
//                    {
//                        exception = ex;

//                    }
//                    finally
//                    {
//                        Assert.IsInstanceOfType(exception, typeof(DbEntityValidationException));
//                    }
//                }
//            }
//        }



//        [TestMethod]
//        public void CanInsertCustomerWithOrderIntoDatabase()
//        {
//            string guidStoredInCompanyForTesting = Guid.NewGuid().ToString();
//            ProductReference bikeProduct;
//            using (var refRepo = new ReferenceDataRepository())
//            {
//                bikeProduct = refRepo.Products.FirstOrDefault(p => p.ProductNumber == "BK-R68R-44");
//            }
//            using (var uow = new UnitOfWork<CustomerServiceContext>())
//            {
//                using (var repo = new CustomerRepository(uow))
//                {
//                    repo.InsertOrUpdateGraph(new Customer
//                    {
//                        FirstName = "Julie",
//                        LastName = "Lerman",
//                        Phone = "802 555 1212",
//                        EmailAddress = "julielerman@gmail.com",
//                        Addresses = new List<Address> { new Address { Street1 = "Main St", City = "Anytown" } },
//                        Title = "Ms.",
//                        CompanyName = guidStoredInCompanyForTesting,
//                        Orders = new List<Order>
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
//                    }
//                                            );
//                    uow.Save();
//                }
//            }
//            using (var repo = new CustomerRepository(new UnitOfWork<CustomerServiceContext>()))
//            {
//                Assert.IsTrue(repo.All.Any(c => c.CompanyName == guidStoredInCompanyForTesting));
//            }
//        }

//        [TestMethod]
//        public void CanRetrieveCustomerReferenceData()
//        {
//            using (var repo = new ReferenceDataRepository())
//            {
//                Assert.IsTrue(repo.Customers.Any(c => c.FirstName == "Julie" && c.LastName == "Lerman"));
//            }
//        }

//        [TestMethod]
//        public void CanNavigateFromReturnsToCustomerServiceAndEditAddress()
//        {
//            int customerId;
//            int addressId = 0;
//            string originalStreet = "";
//            using (var repo = new ReturnedOrderRepository(new UnitOfWork<ReturnsContext>()))
//            {
//                var order = repo.All.FirstOrDefault();
//                customerId = order.CustomerId;
//            }
//            using (var uow = new UnitOfWork<CustomerServiceContext>())
//            {
//                using (var repo = new CustomerRepository(uow))
//                {
//                    //get customer from customer service context
//                    var customer = repo.AllIncluding(c => c.Addresses)
//                      .SingleOrDefault(c => c.Id == customerId);
//                    //find and edit address
//                    if (customer.Addresses.Any())
//                    {
//                        var firstAddress = customer.Addresses.FirstOrDefault();
//                        originalStreet = firstAddress.Street1;
//                        firstAddress.Street1 = "1 " + originalStreet;
//                        addressId = firstAddress.Id;
//                    }
//                    uow.Save();
//                }
//            }
//            using (var repo = new CustomerRepository(new UnitOfWork<CustomerServiceContext>()))
//            {
//                Assert.AreEqual("1 " + originalStreet, repo.All
//                                                               .Where(c => c.Addresses.Any(a => a.Id == addressId))
//                                                               .Select(c => c.Addresses.FirstOrDefault(a => a.Id == addressId))
//                                                               .FirstOrDefault().Street1);
//            }
//        }


//    }

//}
