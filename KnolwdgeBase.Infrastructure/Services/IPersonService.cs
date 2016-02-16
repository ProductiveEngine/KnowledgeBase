using System;
using System.Collections.Generic;
using KB.Business;

namespace KnolwdgeBase.Infrastructure.Services
{
    public interface IPersonService
    {
        IList<Person> GetPeople();
        void GetPeopleAsync(EventHandler<ServiceResult<IList<Person>>> callback);
    }
}