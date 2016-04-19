using System;
using System.Collections.ObjectModel;
using System.Linq;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;
using Services.BLService.BL;

namespace KB.PaSModule.ViewModels
{
    public class PaSViewModel: ViewModelBase, IPaSViewModel
    {
        private readonly ProblemBL _problemBL;
        private readonly SolutionBL _solutionBL;

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

                    Solutions = new ObservableCollection<SolutionVO>(_solutionBL.GetAll().Where(x => x.ProblemID == _selectedProblem.ProblemID).ToList());
                    OnPropertyChanged("Solutions");
                    SelectedSolution = Solutions[0];
                    OnPropertyChanged("SelectedSolution");
                }
            }
        }

        private ObservableCollection<SolutionVO> _subProblems;
        public ObservableCollection<SolutionVO> Solutions
        {
            get { return _subProblems; }
            set { _subProblems = value; }
        }

        private SolutionVO _selectedSolution;
        public SolutionVO SelectedSolution
        {
            get
            {
                return _selectedSolution;
            }
            set
            {
                if (_selectedSolution != value)
                {
                    _selectedSolution = value;                                     
                }
            }
        }
        #endregion //Properties
        #region Constructors
        public PaSViewModel(IRegionManager regionManager)
        {
            _problemBL = new ProblemBL();
            _problems = new ObservableCollection<ProblemVO>(_problemBL.GetAll());

            _solutionBL = new SolutionBL();            
        }
        #endregion //Constructors  
    }
}
