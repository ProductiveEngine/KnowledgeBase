using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Accessors;
using DAL.Models;

namespace KB.BL
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

        public Boolean Save(CategoryVO vo)
        {
            _categoryAccessor.Repo.InsertOrUpdate(vo);
            _categoryAccessor.Save();

            return true;
        }
    }
}
