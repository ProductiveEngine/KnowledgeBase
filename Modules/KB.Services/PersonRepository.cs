using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB.Business;
using KnolwdgeBase.Infrastructure;

namespace KB.Services
{
    public class PersonRepository: IPersonRepository
    {
        private int count = 0;

        public int SavePerson(Person person)
        {
            count++;
            person.LastUpdated = DateTime.Now;
            return count;
        }
    }
}
