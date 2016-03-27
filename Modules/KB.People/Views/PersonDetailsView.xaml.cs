using System.Windows.Controls;
using KB.Business;
using KB.People.ViewModels;
using KnolwdgeBase.Infrastructure;
using Prism.Common;
using Prism.Regions;

namespace KB.People.Views
{
    /// <summary>
    /// Interaction logic for PersonDetailsView.xaml
    /// </summary>
    public partial class PersonDetailsView : UserControl, IPersonDetailsView
    {
        public PersonDetailsView(IPersonDetailsViewModel viewModel)
        {
            InitializeComponent();
            //View first

            ViewModel = viewModel;
            ViewModel.View = this;

            RegionContext.GetObservableContext(this).PropertyChanged += (s, e) =>
            {
                var context = (ObservableObject<object>) s;
                var selectedPerson = (Person) context.Value;
                (ViewModel as IPersonDetailsViewModel).SelectedPerson = selectedPerson;
            };
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}
