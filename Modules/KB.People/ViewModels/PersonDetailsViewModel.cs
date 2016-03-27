using KB.Business;
using KnolwdgeBase.Infrastructure;

namespace KB.People.ViewModels
{
    public class PersonDetailsViewModel : ViewModelBase, IPersonDetailsViewModel
    {        
        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get { return _SelectedPerson; }
            set
            {
                _SelectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        public PersonDetailsViewModel() 
        {
        }
    }
}
