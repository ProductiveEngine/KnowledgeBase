using System.Collections.Generic;
using System.Linq;
using DAL.Accessors;
using DomainClasses.Models;

namespace Services.BLService.BL
{
    public class SubCategoryBL
    {
        private readonly SubCategoryAccessor _subCategoryAccessor;

        public SubCategoryBL()
        {
            _subCategoryAccessor = new SubCategoryAccessor();
        }

        public List<SubCategoryVO> FindAll()
        {
            List<SubCategoryVO> subCatList = null;
            subCatList = _subCategoryAccessor.Repo.All.ToList();

            return subCatList;
        }

        public IQueryable<SubCategoryVO> GetAll()
        {
            return _subCategoryAccessor.Repo.All;
        }

        public bool Save(SubCategoryVO vo)
        {
            _subCategoryAccessor.Repo.InsertOrUpdate(vo);
            return _subCategoryAccessor.Save();            
        }

        public bool Remove(int id)
        {
            _subCategoryAccessor.Repo.Delete(id);
            return _subCategoryAccessor.Save();            
        }
    }
}
