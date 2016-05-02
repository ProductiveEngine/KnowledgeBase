using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Accessors;
using DomainClasses.Models;

namespace Services.BLService.BL
{
    public class ProblemBL
    {
        private readonly ProblemAccessor _problemAccessor;

        public ProblemBL()
        {
            _problemAccessor = new ProblemAccessor();
        }

        public List<ProblemVO> FindAll()
        {
            List<ProblemVO> problermList;

            using (var problemAccessor = new ProblemAccessor())
            {
                problermList = problemAccessor.Repo.All.ToList();
            }
            return problermList;
        }

        public IQueryable<ProblemVO> GetAll()
        {
            IQueryable<ProblemVO> qProblem;

            using (var problemAccessor = new ProblemAccessor())
            {
                qProblem = problemAccessor.Repo.All;
            }
            return qProblem;
        }

        public bool Save(ProblemVO vo)
        {
            _problemAccessor.Repo.InsertOrUpdate(vo);
            return _problemAccessor.Save();
        }

        public bool SaveGraph(ProblemVO vo)
        {
            _problemAccessor.Repo.InsertOrUpdateGraph(vo);
            return _problemAccessor.Save();
        }

        public bool Remove(int id)
        {
            try
            {
                _problemAccessor.Repo.Delete(id);
            }
            catch (Exception)
            {

                return false;
            }
            
            return _problemAccessor.Save();
        }
    }
}
