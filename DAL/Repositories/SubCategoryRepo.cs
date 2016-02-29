using System;
using System.Linq;
using System.Linq.Expressions;
using DAL.Contexts;
using DAL.Repositories.IRepo;
using System.Data.Entity;
using DAL.Base;
using DomainClasses.Base;
using DomainClasses.Models;

namespace DAL.Repositories
{
    public class SubCategoryRepo : ISubCategoryRepo
    {
        private readonly KBContext _context;
        public SubCategoryRepo(IUnitOfWork uow)
        {
            _context = uow.Context as KBContext;
        }

        public IQueryable<SubCategory> All
        {
            get
            {
                return _context.SubCategories;
            }
        }        

        public IQueryable<SubCategory> AllIncluding(params Expression<Func<SubCategory, object>>[] includeProperties)
        {
            IQueryable<SubCategory> query = _context.SubCategories;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var category = _context.SubCategories.Find(id);
            _context.SubCategories.Remove(category);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public SubCategory Find(int id)
        {
            return _context.SubCategories.Find(id);
        }

        public void InsertOrUpdate(SubCategory category)
        {
            if (category.SubCategoryID == default(int))
            {
                _context.SetAdd(category);
            }
            else
            {
                _context.SetModified(category);
            }
        }
        public void InsertOrUpdateGraph(SubCategory customerGraph)
        {
            if (customerGraph.State == State.Added)
            {
                _context.SubCategories.Add(customerGraph);
            }
            else
            {
                _context.SubCategories.Add(customerGraph);
                _context.ApplyStateChanges();
            }
        }
    }
}
//For references objects
//public IQueryable<ProductReference> Products
//{
//    get { return _context.Products.AsNoTracking(); }
//}
//public IQueryable<CustomerReference> Customers
//{
//    get { return _context.Customers.AsNoTracking(); }
//}