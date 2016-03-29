using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace KB.PaSModule.ViewModels
{
    public class WizardVO
    {
        public ProblemVO Problem;
        public SolutionVO Solution;
        public List<StepVO> Steps;

        public void InitializeNew()
        {
            Problem = new ProblemVO();
            Solution = new SolutionVO();
            Steps = new List<StepVO>(1);
        }

        public void InitializeEdit(int problemId)
        {

        }

    }
}
