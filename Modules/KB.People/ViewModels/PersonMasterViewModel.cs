using System.Collections.ObjectModel;
using KB.Business;
using KB.People.Views;
using KnolwdgeBase.Infrastructure;

namespace KB.People.ViewModels
{
    public class PersonMasterViewModel : ViewModelBase, IPersonMasterViewModel
    {
        private ObservableCollection<Person> _people;

        public PersonMasterViewModel(IPersonMasterView view) : base(view)
        {
            CreatePeople();
        }

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                _people = value;
                OnPropertyChanged("People");
            }
        }

        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();

            for (var i = 0; i < 10; i++)
            {
                people.Add(new Person
                {
                    FirstName = string.Format("First {0}", i),
                    LastName = string.Format("Last {0}", i)
                });
            }

            People = people;
        }
    }
}