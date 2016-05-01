using System;
using System.Collections.ObjectModel;
using System.Linq;
using DomainClasses.Models;
using DomainClasses.ViewModels;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;
using Services.BLService.BL;

namespace KB.PaSModule.ViewModels
{
    public class PaSViewModel: ViewModelBase, IPaSViewModel
    {
        private readonly ProblemBL _problemBL;        
        private readonly WizardBL _wizardBL;


        #region Properties          

        private ObservableCollection<ProblemVO> _problems;
        public ObservableCollection<ProblemVO> Problems
        {
            get
            {
                return _problems;
            }
            set { _problems = value; }
        }

        private ProblemVO _selectedProblem;
        public ProblemVO SelectedProblem
        {
            get
            {
                return _selectedProblem;
            }
            set
            {
                if (_selectedProblem != value)
                {
                    _selectedProblem = value;
                    OnPropertyChanged("SelectedProblem");

                    WizardVO wizard = _wizardBL.FindById(_selectedProblem.ProblemID);
                    SelectedSolution = wizard.Solution;
                    Steps = wizard.Steps;
                }
            }
        }                

        private SolutionVO _selectedSolution;
        public SolutionVO SelectedSolution
        {
            get { return _selectedSolution; }
            set
            {
                _selectedSolution = value;
                OnPropertyChanged("SelectedSolution");
            }
        }

        private ObservableCollection<StepVO> _steps;
        public ObservableCollection<StepVO> Steps
        {
            get
            {
                return _steps;
            }
            set { _steps = value; }
        }

        private StepVO _selectedStep;
        public StepVO SelectedStep
        {
            get { return _selectedStep; }
            set {  _selectedStep = value; }
        }
        #endregion //Properties
        #region Constructors
        public PaSViewModel(IRegionManager regionManager)
        {
            _problemBL = new ProblemBL();
            _problems = new ObservableCollection<ProblemVO>(_problemBL.GetAll());

            _wizardBL = new WizardBL();            
        }
        #endregion //Constructors  

        public void ChangeSelectedStep(StepVO step)
        {
            SelectedStep = step;
        }
    }
}
