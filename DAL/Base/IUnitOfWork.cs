using System;
using System.Data.Entity;

namespace DAL.Base
{
    public interface IUnitOfWork: IDisposable
    {
        int Save();
        IContext Context { get; }
    }
}
