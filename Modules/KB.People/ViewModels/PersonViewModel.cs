using System;
using System.ComponentModel;
using System.Windows;
using KB.Business;
using KB.People.Views;
using KnolwdgeBase.Infrastructure;
using Prism.Commands;
using Prism.Events;

namespace KB.People.ViewModels
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {
        private IEventAggregator _eventAggregator;
        private Person _person;
        private IPersonRepository _repository;

        public PersonViewModel(IPersonView view, IEventAggregator eventAggregator, IPersonRepository repository)
            : base(view)
        {
            _repository = repository;
            //CreatePerson();
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand<Person>(Save, CanSave);

            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
        }

        public string ViewName
        {
            get { return string.Format("{0}, {1}", Person.LastName, Person.FirstName); }
        }

        public DelegateCommand<Person> SaveCommand { get; set; }

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                _person.PropertyChanged += Person_PropertyChanged;
                OnPropertyChanged("Person");
            }
        }

        private void Save(Person value)
        {
            //Person.LastUpdated = DateTime.Now;
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(String.Format("{0}, {1}",Person.LastName, Person.FirstName));

            int count = _repository.SavePerson(Person);
            MessageBox.Show(count.ToString()); //DEMO only, NO message boxes in view model!!!
        }

        private bool CanSave(Person value)
        {
            return Person != null && Person.Error == null;
        }

        private void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CreatePerson()
        {
            Person = new Person
            {
                FirstName = "Bob",
                LastName = "Smith",
                Age = 46
            };
        }

        public void CreatePerson(string firstName, string lastName)
        {
            Person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 0
            };
        }
    }
}