using System;
using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class WizardAccessor
    {
        private readonly KBUOW<KBContext> _uow;
        private readonly ProblemRepo _repoProblem;
        private readonly SolutionRepo _repoSoltuion;
        private readonly StepRepo _repoStep;

        public WizardAccessor()
        {
            _uow = new KBUOW<KBContext>();
            _repoProblem = new ProblemRepo(_uow);
            _repoSoltuion = new SolutionRepo(_uow);
            _repoStep = new StepRepo(_uow);
        }

        public ProblemRepo RepoProblem
        {
            get { return _repoProblem;}
        }

        public SolutionRepo RepoSolution
        {
            get { return _repoSoltuion; }
        }

        public StepRepo RepoStep
        {
            get { return _repoStep; }
        }

        public Boolean Save()
        {
            return _uow.Save() > -1;
        }

    }
}
