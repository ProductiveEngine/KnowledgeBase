using System.Windows;
using KnolwdgeBase.Infrastructure;

namespace KnoledgeBase
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window, IView
    {
        public Shell(IShellViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}
