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
            List<SubCategoryVO> subCatList;

            using (var subCategoryAccessor = new SubCategoryAccessor())
            {
                subCatList = subCategoryAccessor.Repo.All.ToList();
            }            
            return subCatList;
        }

        public IQueryable<SubCategoryVO> GetAll()
        {
            IQueryable<SubCategoryVO> qSubCategory;

            using (var subCategoryAccessor = new SubCategoryAccessor())
            {
                qSubCategory = subCategoryAccessor.Repo.All;
            }
            return qSubCategory;
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
