using DAL.Base;
using System.Data.Entity;
using DomainClasses.Models;

namespace DAL.Contexts
{
    public interface IKBContext : IContext
    {
        IDbSet<Category> Categories { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Problem> Problems { get; set; }
        IDbSet<Solution> Solutions { get; set; }
        IDbSet<Step> Steps { get; set; }
        IDbSet<SubCategory> SubCategories { get; set; }
        IDbSet<UsefulInfo> UsefulInfos { get; set; }

    }

    public class KBContext : BaseContext<KBContext>, IKBContext
    {
        public IDbSet<Category> Categories {get; set;}
        public IDbSet<Comment> Comments {get; set;}
        public IDbSet<Problem> Problems {get; set;}
        public IDbSet<Solution> Solutions {get; set;}
        public IDbSet<Step> Steps {get; set;}
        public IDbSet<SubCategory> SubCategories {get; set;}
        public IDbSet<UsefulInfo> UsefulInfos { get; set;}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new LineItemMap());
        //}

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
    }
}


//public class DatabaseSeedingInitializer : DropCreateDatabaseAlways<CompanyDatabase>
//{
//    protected override void Seed(CompanyDatabase context)
//    {
//        var bikeProduct = new Product
//        {
//            ProductNumber = "BK-R68R-44",
//            Name = "Bike Saturday",
//            Category = new Category { Name = "Bikes" },
//            Color = "Blue",
//            ListPrice = 500M,
//            ShippingWeight = 30M,
//            SellStartDate = new System.DateTime(2011, 1, 1)
//        };

//        var cust = new Customer
//        {
//            FirstName = "Julie",
//            LastName = "Lerman",
//            Phone = "802 555 1212",
//            EmailAddress = "julielerman@gmail.com",
//            Addresses = new List<Address> { new Address { Street1 = "Main St", City = "Anytown" } },
//            Title = "Ms.",
//            CompanyName = "The Data Farm",
//            Orders = new List<Order>
//                         {
//                           new Order
//                           {
//                             OrderDate = DateTime.Now,
//                             DueDate = DateTime.Now.AddDays(7),
//                             ModifiedDate = DateTime.Now,
//                             LineItems = new List<LineItem>
//                             {
//                               new LineItem
//                               {
//                                 OrderQty = 1,
//                                 Product=bikeProduct,
//                                 UnitPrice = bikeProduct.ListPrice
//                               }
//                             }
//                           }
//                         }
//        };
//        context.Customers.Add(cust);
//        context.Returns.Add(new Return
//        {
//            DateTime = DateTime.Now,
//            Order = new Order
//            {
//                OrderDate = DateTime.Now,
//                DueDate = DateTime.Now.AddDays(7),
//                ModifiedDate = DateTime.Now,
//                LineItems = new List<LineItem>
//                             {
//                               new LineItem
//                               {
//                                 OrderQty = 4,
//                                 Product=bikeProduct,
//                                 UnitPrice = bikeProduct.ListPrice
//                               }
//                             }
//            }
//        });

//    }
//}


//public class MyContext : DbContext
//{
//    public override int SaveChanges()
//    {
//        ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;

//        //Find all Entities that are Added/Modified that inherit from my EntityBase
//        IEnumerable<ObjectStateEntry> objectStateEntries =
//            from e in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
//            where
//                e.IsRelationship == false &&
//                e.Entity != null &&
//                typeof(EntityBase).IsAssignableFrom(e.Entity.GetType())
//            select e;

//        var currentTime = DateTime.Now;

//        foreach (var entry in objectStateEntries)
//        {
//            var entityBase = entry.Entity as EntityBase;

//            if (entry.State == EntityState.Added)
//            {
//                entityBase.CreatedDate = currentTime;
//            }

//            entityBase.LastModifiedDate = currentTime;
//        }

//        return base.SaveChanges();
//    }
//}