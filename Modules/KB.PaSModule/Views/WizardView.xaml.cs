using System.Windows;
using KB.PaSModule.ViewModels;
using KnolwdgeBase.Infrastructure;

namespace KB.PaSModule.Views
{
    /// <summary>
    /// Interaction logic for WizardView.xaml
    /// </summary>
    public partial class WizardView : Window, IWizardView
    {       

        public WizardView(WizardViewModel wizardViewModel)
        {
            InitializeComponent();
            DataContext = wizardViewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        private void Wizard_Finish(object sender, RoutedEventArgs e)
        {
            ((WizardViewModel) ViewModel).ManageSave();
        }
    }
}
