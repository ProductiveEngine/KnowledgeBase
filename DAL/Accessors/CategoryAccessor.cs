using System;
using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class CategoryAccessor: IDisposable
    {
        private readonly KBUOW<KBContext> _uow;
        private readonly CategoryRepo _repo;

        public CategoryAccessor()
        {
            _uow = new KBUOW<KBContext>();
            _repo = new CategoryRepo(_uow);
        }

        public CategoryRepo Repo
        {
            get { return _repo; }
        }

        public Boolean Save()
        {
            return _uow.Save()>-1;
        }

        public void Dispose()
        {            
        }
    }
}
