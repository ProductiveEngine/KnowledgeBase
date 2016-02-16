using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using KB.Business;
using KnolwdgeBase.Infrastructure.Services;

namespace Services.PersonService
{
    public class PersonService : IPersonService
    {
        private static readonly string Avatar1Uri = @"/Services.PersonService;component/Images/MC900432625.PNG";
        private static readonly string Avatar2Uri = @"/Services.PersonService;component/Images/MC900433938.PNG";

        public IList<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 50; i++)
            {
                var person = new Person();
                person.FirstName = String.Format("First{0}", i);
                person.LastName = String.Format("Last{0}", i);
                person.Age = i;
                person.Email = String.Format("{0}.{1}@domain.com", person.FirstName, person.LastName);
                person.ImagePath = GetPersonImagePath(i);
                people.Add(person);
                Thread.Sleep(80); //simulate longer process
            }

            return people;
        }

        public void GetPeopleAsync(EventHandler<ServiceResult<IList<Person>>> callback)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (o, e) =>
                {
                    e.Result = GetPeople();
                };
            bw.RunWorkerCompleted += (o, e) =>
                {
                    callback.Invoke(this, new ServiceResult<IList<Person>>((IList<Person>)e.Result));
                };
            bw.RunWorkerAsync();
        }

        private static string GetPersonImagePath(int index)
        {
            return index % 2 == 0 ? Avatar1Uri : Avatar2Uri;
        }
    }
}
