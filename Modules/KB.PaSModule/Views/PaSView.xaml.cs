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
            PaSViewModel pas = (PaSViewModel)ViewModel;

            new WizardView(new WizardViewModel(null)).ShowDialog();

            pas.RefreshProblemList();            
        }
       
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            PaSViewModel pas = (PaSViewModel)ViewModel;

            if ((ProblemVO) lstProblems.SelectedItem != null)
            {
                int problemId = ((ProblemVO) lstProblems.SelectedItem).ProblemID;

                WizardViewModel wvm = new WizardViewModel(null);
                wvm.InitializeEdit(problemId);
                new WizardView(wvm).ShowDialog();

                pas.RefreshProblemList();                
            }
        }   

        private void lstSteps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((PaSViewModel) ViewModel).ChangeSelectedStep((StepVO) lstSteps.SelectedItem);
            lstSteps.Items.Refresh();
        }
    }
}
