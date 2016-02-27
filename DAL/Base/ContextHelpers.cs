using System.Data.Entity;
using DomainClasses.Base;

namespace DAL.Base
{
    public static class ContextHelpers
    {
        //Only use with short lived contexts 
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = StateHelpers.ConvertState(stateInfo.State);
            }
        }
    }
}
