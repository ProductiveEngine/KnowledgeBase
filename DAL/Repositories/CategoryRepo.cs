using System;
using System.Linq;
using System.Linq.Expressions;
using DAL.Contexts;
using DAL.Models;
using DAL.Repositories.IRepo;
using DAL.UOW;
using System.Data.Entity;
using DAL.Base;

namespace DAL.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IKBContext _context;
        public CategoryRepo(IUnitOfWork uow)
        {
            _context = uow.Context as IKBContext;
        }

        public IQueryable<CategoryVO> All
        {
            get
            {
                return _context.Categories;
            }
        }

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
    }
}
