using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DomainClasses.Models;
using DomainClasses.ViewModels;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;
using Services.BLService.BL;

namespace KB.PaSModule.ViewModels
{
    public class WizardViewModel: ViewModelBase, IWizardViewModel
    {
        private readonly CategoryBL _categoryBL;
        private readonly SubCategoryBL _subCategoryBL;
        private readonly WizardBL _wizardBL;
        private readonly ProblemBL _problemBl;

        #region Properties         

        private ObservableCollection<CategoryVO> _categories;
        public ObservableCollection<CategoryVO> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        private CategoryVO _selectedCategory;
        public CategoryVO SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged("SelectedCategory");

                    SubCategories = new ObservableCollection<SubCategoryVO>(_subCategoryBL.GetAll().Where(x => x.CategoryID == _selectedCategory.CategoryID).ToList());
                    OnPropertyChanged("SubCategories");
                    SelectedSubCategory = SubCategories[0];
                    OnPropertyChanged("SelectedSubCategory");                    
                }
            }
        }

        private ObservableCollection<SubCategoryVO> _subCategories;
        public ObservableCollection<SubCategoryVO> SubCategories
        {
            get { return _subCategories; }
            set { _subCategories = value; }
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

        private SubCategoryVO _selectedSubCategory;
        public SubCategoryVO SelectedSubCategory
        {
            get
            {
                return _selectedSubCategory;
            }
            set
            {
                if (_selectedSubCategory != value)
                {
                    _selectedSubCategory = value;
                    Problem.SubCategoryID = _selectedSubCategory.SubCategoryID;
                    OnPropertyChanged("SelectedCategory");
                }
            }
        }

        private WizardVO _wizard;
        public WizardVO Wizard
        {
            get { return _wizard; }
            set
            {
                _wizard = value;
                //OnPropertyChanged("WizardVo");
            }
        }

        private ProblemVO _problem;

        public ProblemVO Problem
        {
            get { return _problem;}
            set { _problem = value; }
        }
       
        #endregion //Properties
        #region Constructors
        public WizardViewModel(IRegionManager regionManager)
        {
            Wizard = new WizardVO();            

            _categoryBL = new CategoryBL();
            _categories = new ObservableCollection<CategoryVO>(_categoryBL.FindAll());

            _subCategoryBL = new SubCategoryBL();     
            _wizardBL = new WizardBL();     
            
            Problem = new ProblemVO();
            
            _problemBl = new ProblemBL();            
        }

        #endregion //Constructors 

        public void AddSolution()
        {
            if (_problem.Solutions == null)
            {
                _problem.Solutions = new List<SolutionVO>();
            }

            SolutionVO solution = new SolutionVO();
            solution.ProblemID = _problem.ProblemID;

            _problem.Solutions.Add(solution);           
        }

        public void ManageSave()
        {
            if (SelectedSubCategory != null)
            {
                _wizard.Problem.SubCategoryID = SelectedSubCategory.SubCategoryID;
            }
            
            //_problemBl.SaveGraph(_problem);
            _wizardBL.Save(_wizard);
        }

        public void AddStep()
        {
            _wizard.Steps.Add(new StepVO() {Title = "-"});
        }

        public void DeleteStep(StepVO step)
        {
            _wizard.Steps.Remove(step);
        }

        public void ChangeSelectedStep(StepVO step)
        {
            SelectedStep = step;
        }

    }
}
