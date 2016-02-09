using DAL.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL
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
