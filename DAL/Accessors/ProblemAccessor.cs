using System;
using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class ProblemAccessor: IDisposable
    {
        private readonly KBUOW<KBContext> _uow;
        private readonly ProblemRepo _repo;

        public ProblemAccessor()
        {
            _uow = new KBUOW<KBContext>();
            _repo = new ProblemRepo(_uow);
        }

        public ProblemRepo Repo
        {
            get { return _repo; }
        }

        public Boolean Save()
        {
            return _uow.Save() > -1;
        }

        public void Dispose()
        {            
        }
    }
}
