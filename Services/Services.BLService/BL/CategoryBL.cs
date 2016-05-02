using System.Collections.Generic;
using System.Linq;
using DAL.Accessors;
using DomainClasses.Models;

namespace Services.BLService.BL
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
            List<CategoryVO> catList;

            using (var categoryAccessor = new CategoryAccessor())
            {
                catList = _categoryAccessor.Repo.All.ToList();
            }
            return catList;
        }

        public IQueryable<CategoryVO> GetAll()
        {
            IQueryable<CategoryVO> qCateogry;

            using (var categoryAccessor = new CategoryAccessor())
            {
                qCateogry = categoryAccessor.Repo.All;
            }
            return qCateogry;
        }

        public bool Save(CategoryVO vo)
        {
            _categoryAccessor.Repo.InsertOrUpdate(vo);
            return _categoryAccessor.Save();           
        }

        public bool Remove(int id)
        {
            _categoryAccessor.Repo.Delete(id);
            return _categoryAccessor.Save();                                    
        }
    }
}
