using System.ComponentModel;
using System.Collections.ObjectModel;
using KB.Business;
using KnolwdgeBase.Infrastructure;
using KnolwdgeBase.Infrastructure.Services;

namespace ModuleA
{
    public class ContentAViewViewModel : IContentAViewViewModel, INotifyPropertyChanged
    {
        private readonly IPersonService _personService;

        #region Properties

        private ObservableCollection<Person> _People;
        public ObservableCollection<Person> People
        {
            get { return _People; }
            set
            {
                _People = value;
                OnPropertyChanged("People");
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        #endregion //Properties

        #region Constructors

        public ContentAViewViewModel(IPersonService personService)
        {
            _personService = personService;
            LoadPeople();
        }

        #endregion //Constructors

        #region Commands



        #endregion //Commands

        #region Methods

        private void LoadPeople()
        {
            IsBusy = true;
            _personService.GetPeopleAsync((sender, result) =>
            {
                People = new ObservableCollection<Person>(result.Object);
                IsBusy = false;
            });
        }

        #endregion //Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion //INotifyPropertyChanged

        public IView View { get; set; }
    }
}
