using System.Windows;
using DomainClasses.Models;
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

        private void btnAddSolution_Click(object sender, RoutedEventArgs e)
        {
            ((WizardViewModel) ViewModel).AddSolution();
        }

        private void btnSavea_Click(object sender, RoutedEventArgs e)
        {
            ((WizardViewModel)ViewModel).ManageSave();
        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            ((WizardViewModel)ViewModel).AddStep();
        }

        private void btnDeleteStep_Click(object sender, RoutedEventArgs e)
        {
            //ListView1.Items.RemoveAt(ListView1.Items.IndexOf(ListView1.SelectedItem));
            ((WizardViewModel)ViewModel).DeleteStep();
        }

        private void lstSteps_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {            
            ((WizardViewModel)ViewModel).ChangeSelectedStep((StepVO)lstSteps.SelectedItem);
            lstSteps.Items.Refresh();
        }
    }
}
