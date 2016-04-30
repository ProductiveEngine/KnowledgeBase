using System.Collections.ObjectModel;
using System.ComponentModel;
using DomainClasses.Models;

namespace DomainClasses.ViewModels
{
    public class WizardVO: INotifyPropertyChanged

    {                        
        public WizardVO()
        {
            Problem = new ProblemVO();
            Solution = new SolutionVO();
            Steps = new ObservableCollection<StepVO>();
        }

        private ProblemVO _problem;
        public ProblemVO Problem
        {
            get { return _problem; }
            set
            {
                _problem = value;
            }
        }

        private SolutionVO _solution;
        public SolutionVO Solution
        {
            get { return _solution; }
            set
            {
                _solution = value;
            }
        }

        private ObservableCollection<StepVO> _steps;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public ObservableCollection<StepVO> Steps
        {
            get { return _steps; }
            set
            {
                _steps = value;
                OnPropertyChanged("Steps");
            }
        }

        public bool ValidateVO()
        {
            bool ok = true;
            ok = Problem != null && Problem.Error == null
                     && Problem.SubCategoryID > 0
                     && Solution != null && Solution.Error == null;

            if (Steps != null && Steps.Count > 0)
            {
                foreach (StepVO step in Steps)
                {
                    ok = ok && step.Error == null && step.Title.Length > 2 ;
                }
            }

            return ok;
        }
    }
}
