using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DomainClasses.Models;
using DomainClasses.ViewModels;
using KnolwdgeBase.Infrastructure;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using Services.BLService.BL;

namespace KB.PaSModule.ViewModels
{
    public class PaSViewModel: ViewModelBase, IPaSViewModel
    {
        private readonly ProblemBL _problemBL;        
        private readonly WizardBL _wizardBL;

        public InteractionRequest<INotification> ProblemDeletionFailedNotificationRequest { get; set; }
        public InteractionRequest<IConfirmation> DeleteProblemConfirmRequest { get; set; }
        public ICommand DeleteProblemCmd { get; set; }
        public ICommand SearchProblemCmd { get; set; }

        #region Properties          

        private string _sProblemTitle;

        public string SProblemTitle
        {
            get
            {
                return _sProblemTitle;
            }
            set
            {
                _sProblemTitle = value; 
                OnPropertyChanged("SProblemTitle");
            }
        }

        private ObservableCollection<ProblemVO> _problems;
        public ObservableCollection<ProblemVO> Problems
        {
            get
            {
                return _problems;
            }
            set
            {
                _problems = value;
                OnPropertyChanged("Problems");
            }
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

                    if (_selectedProblem != null)
                    {
                        WizardVO wizard = _wizardBL.FindById(_selectedProblem.ProblemID);
                        SelectedSolution = wizard.Solution;
                        Steps = wizard.Steps;
                    }
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
            set
            {
                _steps = value;
                OnPropertyChanged("Steps");
            }
        }

        private StepVO _selectedStep;
        public StepVO SelectedStep
        {
            get { return _selectedStep; }
            set
            {
                _selectedStep = value;
                OnPropertyChanged("SelectedStep");
            }
        }
        #endregion //Properties
        #region Constructors
        public PaSViewModel(IRegionManager regionManager)
        {
            _problemBL = new ProblemBL();
            _problems = new ObservableCollection<ProblemVO>(_problemBL.FindAll());

            _wizardBL = new WizardBL();

            DeleteProblemCmd = new DelegateCommand<ProblemVO>(RaiseDeleteConfirmation);
            DeleteProblemConfirmRequest = new InteractionRequest<IConfirmation>();
            ProblemDeletionFailedNotificationRequest = new InteractionRequest<INotification>();

            SearchProblemCmd = new DelegateCommand(Search);
        }
        #endregion //Constructors  

        public void RefreshProblemList()
        {
            Problems = new ObservableCollection<ProblemVO>(_problemBL.FindAll());
            SelectedStep = null;
            SelectedSolution = null;
            Steps = null;
        }

        public void RaiseDeleteConfirmation(ProblemVO problem)
        {
            DeleteProblemConfirmRequest.Raise(new Confirmation { Title = "Confirmation", Content = "Are you sure you want\nto delete the problem ?" },
                r =>
                {
                    if (r.Confirmed)
                    {
                        if (problem != null)
                        {
                            bool ok = DeleteProblem(problem.ProblemID);

                            if (!ok)
                            {
                                ProblemDeletionFailedNotificationRequest.Raise(new Notification
                                {
                                    Title = "Information",
                                    Content = "Deletion was NOT successful"
                                });
                            }
                            else
                            {
                                RefreshProblemList();
                            }
                        }
                    }
                });            
        }

        public void Search()
        {
            List<ProblemVO> pr = _problemBL.GetAll().Where(x => x.Title.Contains(SProblemTitle) || x.Tags.Contains(SProblemTitle)).ToList();
            
            Problems = new ObservableCollection<ProblemVO>(pr);            
        }

        public bool DeleteProblem(int problemId)
        {            
            return _problemBL.Remove(problemId);
        }

        public void ChangeSelectedStep(StepVO step)
        {
            SelectedStep = step;
        }
    }
}
