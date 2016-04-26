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
            List<ProblemVO> catList = null;
            catList = _problemAccessor.Repo.All.ToList();

            return catList;
        }

        public IQueryable<ProblemVO> GetAll()
        {
            return _problemAccessor.Repo.All;
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
            _problemAccessor.Repo.Delete(id);
            return _problemAccessor.Save();
        }
    }
}
