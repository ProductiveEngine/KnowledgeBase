using DAL.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KBTest
{
    [TestClass]
    public class TestContext
    {
        public TestContext()
        {
            ReCreateKBDatabaseForTesting();
        }

        public void ReCreateKBDatabaseForTesting()
        {
            //Database.SetInitializer(new DatabaseSeedingInitializer());
            //using (var context = new KBContext())
            //{
            //    context.Database.Initialize(true);
            //}
        }
    }
}
