using DAL.Base;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.SaveChanges();
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
