using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Accessors;
using DomainClasses.Models;

namespace BLService.BL
{
    public class CategoryBL
    {
        private readonly CategoryAccessor _categoryAccessor;

        public CategoryBL()
        {
            _categoryAccessor = new CategoryAccessor();
        }

        public List<Category> FindAll()
        {
            List<Category> catList = null;
            catList = _categoryAccessor.Repo.All.ToList();

            return catList;
        }

        public IQueryable<Category> GetAll()
        {            
            return _categoryAccessor.Repo.All;            
        }

        public Boolean Save(Category vo)
        {
            _categoryAccessor.Repo.InsertOrUpdate(vo);
            _categoryAccessor.Save();

            return true;
        }

        public Boolean Remove(int id)
        {
            _categoryAccessor.Repo.Delete(id);
            _categoryAccessor.Save();

            return true;
        }
    }
}
