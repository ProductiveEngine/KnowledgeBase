using System.Windows.Controls;
using KnolwdgeBase.Infrastructure;

namespace KB.People.Views
{
    /// <summary>
    /// Interaction logic for PersonMasterView.xaml
    /// </summary>
    public partial class PersonMasterView : UserControl, IPersonMasterView
    {
        public PersonMasterView()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
