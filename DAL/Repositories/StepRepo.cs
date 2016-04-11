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
    public class StepRepo : IStepRepo
    {
        private readonly KBContext _context;
        public StepRepo(IUnitOfWork uow)
        {
            _context = uow.Context as KBContext;
        }

        public IQueryable<StepVO> All
        {
            get
            {
                return _context.Steps;
            }
        }

        public IQueryable<StepVO> AllIncluding(params Expression<Func<StepVO, object>>[] includeProperties)
        {
            IQueryable<StepVO> query = _context.Steps;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var category = _context.Steps.Find(id);
            _context.Steps.Remove(category);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public StepVO Find(int id)
        {
            return _context.Steps.Find(id);
        }

        public void InsertOrUpdate(StepVO category)
        {
            if (category.StepID == default(int))
            {
                _context.SetAdd(category);
            }
            else
            {
                _context.SetModified(category);
            }
        }
        public void InsertOrUpdateGraph(StepVO customerGraph)
        {
            if (customerGraph.State == State.Added)
            {
                _context.Steps.Add(customerGraph);
            }
            else
            {
                _context.Steps.Add(customerGraph);
                _context.ApplyStateChanges();
            }
        }
    }
}
