using System;
using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class SolutionAccessor
    {
        private readonly KBUOW<KBContext> _uow;
        private readonly SolutionRepo _repo;

        public SolutionAccessor()
        {
            _uow = new KBUOW<KBContext>();
            _repo = new SolutionRepo(_uow);
        }

        public SolutionRepo Repo
        {
            get { return _repo; }
        }

        public Boolean Save()
        {
            return _uow.Save() > -1;
        }
    }
}
