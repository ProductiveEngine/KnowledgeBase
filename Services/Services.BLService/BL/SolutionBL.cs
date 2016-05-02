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
            List<SolutionVO> catList;

            using (var solutionAccessor = new SolutionAccessor())
            {
                catList = solutionAccessor.Repo.All.ToList();
            }
            return catList;
        }

        public IQueryable<SolutionVO> GetAll()
        {
            IQueryable<SolutionVO> qSolution;

            using (var solutionAccessor = new SolutionAccessor())
            {
                qSolution = solutionAccessor.Repo.All;
            }
            return qSolution;
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
