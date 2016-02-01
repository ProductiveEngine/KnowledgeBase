using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories.IRepo
{
    public interface IEntityRepo<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T entity);
        void Delete(int id);
    }
}
