using System;
using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class SubCategoryAccessor
    {
        private readonly KBUOW<KBContext> _uow;
        private readonly SubCategoryRepo _repo;

        public SubCategoryAccessor()
        {
            _uow = new KBUOW<KBContext>();
            _repo = new SubCategoryRepo(_uow);
        }

        public SubCategoryRepo Repo
        {
            get { return _repo; }
        }

        public Boolean Save()
        {
            return _uow.Save() > -1;
        }
    }
}
