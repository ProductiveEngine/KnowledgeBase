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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly KBContext _context;
        public CategoryRepo(IUnitOfWork uow)
        {
            _context = uow.Context as KBContext;
        }

        public IQueryable<CategoryVO> All
        {
            get
            {
                return _context.Categories;
            }
        }
        //public List<Customer> AllCustomers
        //{
        //    get { return _context.Customers.ToList(); }
        //}
        //public List<Customer> AllCustomersWhoHaveOrdered
        //{
        //    get { return _context.Customers.Where(c => c.Orders.Any()).ToList(); }
        //}

        public IQueryable<CategoryVO> AllIncluding(params Expression<Func<CategoryVO, object>>[] includeProperties)
        {
            IQueryable<CategoryVO> query = _context.Categories;

            foreach(var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public CategoryVO Find(int id)
        {
            return _context.Categories.Find(id);
        }

        public void InsertOrUpdate(CategoryVO category)
        {
            if(category.CategoryID == default(int))
            {
                _context.SetAdd(category);
            }
            else
            {
                _context.SetModified(category);
            }
        }
        public void InsertOrUpdateGraph(CategoryVO customerGraph)
        {
            if (customerGraph.State == State.Added)
            {
                _context.Categories.Add(customerGraph);
            }
            else
            {
                _context.Categories.Add(customerGraph);
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