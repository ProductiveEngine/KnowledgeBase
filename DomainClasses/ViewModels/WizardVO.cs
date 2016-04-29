using System.Collections.Generic;
using System.Collections.ObjectModel;
using DomainClasses.Models;

namespace DomainClasses.ViewModels
{
    public class WizardVO
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
        public ObservableCollection<StepVO> Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }
    }
}
