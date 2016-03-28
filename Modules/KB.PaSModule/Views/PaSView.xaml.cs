using System.Windows;
using System.Windows.Controls;
using KB.PaSModule.ViewModels;
using KnolwdgeBase.Infrastructure;

namespace KB.PaSModule.Views
{
    /// <summary>
    /// Interaction logic for PaSView.xaml
    /// </summary>
    public partial class PaSView : UserControl, IPaSView
    {
        private PaSViewModel _pas = null;

        public PaSView(PaSViewModel paSViewModel)
        {
            _pas = paSViewModel;
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            new WizardView(new WizardViewModel(null)).Show();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }        
    }
}
