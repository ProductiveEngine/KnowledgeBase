using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<CategoryVO> FindAll()
        {
            List<CategoryVO> catList = null;
            catList = _categoryAccessor.Repo.All.ToList();

            return catList;
        }

        public IQueryable<CategoryVO> GetAll()
        {            
            return _categoryAccessor.Repo.All;            
        }

        public Boolean Save(CategoryVO vo)
        {
            _categoryAccessor.Repo.InsertOrUpdate(vo);
            return _categoryAccessor.Save();           
        }

        public Boolean Remove(int id)
        {
            _categoryAccessor.Repo.Delete(id);
            return _categoryAccessor.Save();                                    
        }
    }
}
