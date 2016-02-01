using DAL.Base;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    public class KBUOW: IUnitOfWork<KBContext>
    {        
        private readonly KBContext _context;

        public KBUOW()
        {
            _context = new KBContext();
        }

        public KBUOW(KBContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public KBContext Context
        {
            get { return _context; }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }    
}
