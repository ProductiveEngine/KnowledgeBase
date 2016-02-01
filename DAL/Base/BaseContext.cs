using System.Data.Entity;

namespace DAL.Base
{
    public class BaseContext<TContext>:DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        protected BaseContext() : base("name=KBDB")
        {

        }
    }
}
