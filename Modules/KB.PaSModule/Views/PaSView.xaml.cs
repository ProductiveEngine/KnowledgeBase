using System.Windows;
using System.Windows.Controls;
using DomainClasses.Models;
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
            InitializeComponent();
            DataContext = paSViewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            new WizardView(new WizardViewModel(null)).Show();
        }
       
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if ((ProblemVO) lstProblems.SelectedItem != null)
            {
                int problemId = ((ProblemVO) lstProblems.SelectedItem).ProblemID;

                WizardViewModel wvm = new WizardViewModel(null);
                wvm.InitializeEdit(problemId);
                new WizardView(wvm).Show();
            }
        }

        private void lstSteps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((WizardViewModel)ViewModel).ChangeSelectedStep((StepVO)lstSteps.SelectedItem);
            lstSteps.Items.Refresh();
        }
    }
}
