using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Base;
using DAL.Contexts;
using DAL.Repositories.IRepo;
using DomainClasses.Base;
using DomainClasses.Models;

namespace DAL.Repositories
{
    public class ProblemRepo : IProblemRepo
    {
        private readonly KBContext _context;
        public ProblemRepo(IUnitOfWork uow)
        {
            _context = uow.Context as KBContext;
        }

        public IQueryable<ProblemVO> All
        {
            get
            {
                return _context.Problems;
            }
        }

        public IQueryable<ProblemVO> AllIncluding(params Expression<Func<ProblemVO, object>>[] includeProperties)
        {
            IQueryable<ProblemVO> query = _context.Problems;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var problem = _context.Problems.Find(id);
            _context.Problems.Remove(problem);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ProblemVO Find(int id)
        {
            return _context.Problems.Find(id);
        }

        public ProblemVO FindAsNoTracking(int id)
        {
            return _context.Problems.AsNoTracking().FirstOrDefault(x => x.ProblemID == id);
        }

        public void InsertOrUpdate(ProblemVO problem)
        {
            if (problem.ProblemID == default(int))
            {
                _context.SetAdd(problem);
            }
            else
            {
                _context.SetModified(problem);
            }
        }

        public void InsertOrUpdateGraph(ProblemVO customerGraph)
        {
            if (customerGraph.State == State.Added)
            {
                _context.Problems.Add(customerGraph);
            }
            else
            {
                _context.Problems.Add(customerGraph);
                _context.ApplyStateChanges();
            }
        }

        public void Detach(ProblemVO problem)
        {
            
        }
    }
}
