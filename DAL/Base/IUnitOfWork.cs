using System;
using System.Data.Entity;

namespace DAL.Base
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        int Save();
        TContext Context { get; }
    }
}
