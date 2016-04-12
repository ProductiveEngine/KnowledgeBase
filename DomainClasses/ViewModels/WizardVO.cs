using System.Collections.Generic;
using DomainClasses.Models;

namespace DomainClasses.ViewModels
{
    public class WizardVO
    {                
        public List<StepVO> Steps;

        public WizardVO()
        {
            Problem = new ProblemVO();
            Solution = new SolutionVO();
            Steps = new List<StepVO>(1);
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
    }
}
