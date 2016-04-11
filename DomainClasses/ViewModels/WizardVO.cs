using System.Collections.Generic;
using DomainClasses.Models;

namespace DomainClasses.ViewModels
{
    public class WizardVO
    {
        public ProblemVO Problem;
        public SolutionVO Solution;
        public List<StepVO> Steps;

        public WizardVO()
        {
            Problem = new ProblemVO();
            Solution = new SolutionVO();
            Steps = new List<StepVO>(1);
        }
    }
}
