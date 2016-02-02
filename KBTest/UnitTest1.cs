using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.Accessor;
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

            List<CategoryVO> q = _categoryAccessor.Repo.AllIncluding(x => x.Title == "Databases").ToList();

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
