using System.Collections.Generic;
using System.Linq;
using DAL.Accessors;
using DomainClasses.Models;

namespace Services.BLService.BL
{
    public class SolutionBL
    {
        private readonly SolutionAccessor _solutionAccessor;

        public SolutionBL()
        {
            _solutionAccessor = new SolutionAccessor();
        }

        public List<SolutionVO> FindAll()
        {
            List<SolutionVO> catList = null;
            catList = _solutionAccessor.Repo.All.ToList();

            return catList;
        }

        public IQueryable<SolutionVO> GetAll()
        {
            return _solutionAccessor.Repo.All;
        }

        public bool Save(SolutionVO vo)
        {
            _solutionAccessor.Repo.InsertOrUpdate(vo);
            return _solutionAccessor.Save();
        }

        public bool Remove(int id)
        {
            _solutionAccessor.Repo.Delete(id);
            return _solutionAccessor.Save();
        }
    }
}
