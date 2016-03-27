using DAL.Base;
using System;
using KnolwdgeBase.Infrastructure;

namespace DAL.UOW
{
    public class KBUOW<TContext>: IUnitOfWork 
        where TContext : IContext, new()
    {        
        private readonly IContext _context;

        public KBUOW()
        {
            _context = new TContext();
        }

        public KBUOW(IContext context)
        {
            _context = context;
        }
        public int Save()
        {
            int result = -1;

            try
            {
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {                
                Logger.Log(Logger.Level.Exception, "KBUOW", ex.ToString());
            }
            return result;
        }

        public IContext Context
        {
            get { return (TContext)_context; }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }    
}
