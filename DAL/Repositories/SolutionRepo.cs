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
    public class SolutionRepo : ISolutionRepo
    {
        private readonly KBContext _context;
        public SolutionRepo(IUnitOfWork uow)
        {
            _context = uow.Context as KBContext;
        }

        public IQueryable<SolutionVO> All
        {
            get
            {
                return _context.Solutions;
            }
        }

        public IQueryable<SolutionVO> AllIncluding(params Expression<Func<SolutionVO, object>>[] includeProperties)
        {
            IQueryable<SolutionVO> query = _context.Solutions;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var solution = _context.Solutions.Find(id);
            _context.Solutions.Remove(solution);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public SolutionVO Find(int id)
        {
            return _context.Solutions.Find(id);
        }

        public SolutionVO FindAsNoTracking(int id)
        {
            return _context.Solutions.AsNoTracking().FirstOrDefault(x => x.SolutionId == id);
        }

        public void InsertOrUpdate(SolutionVO solution)
        {
            if (solution.SolutionId == default(int))
            {
                _context.SetAdd(solution);
            }
            else
            {
                _context.SetModified(solution);
            }
        }
        public void InsertOrUpdateGraph(SolutionVO customerGraph)
        {
            if (customerGraph.State == State.Added)
            {
                _context.Solutions.Add(customerGraph);
            }
            else
            {
                _context.Solutions.Add(customerGraph);
                _context.ApplyStateChanges();
            }
        }
    }
}
