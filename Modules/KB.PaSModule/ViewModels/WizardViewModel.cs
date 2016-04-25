using System;
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
                    WizardVo.Problem.SubCategory = _selectedSubCategory;
                    OnPropertyChanged("SelectedCategory");
                }
            }
        }

        private WizardVO _wizardVo;
        public WizardVO WizardVo
        {
            get { return _wizardVo; }
            set
            {
                _wizardVo = value;
                //OnPropertyChanged("WizardVo");
            }
        }

        private ProblemVO _problemVo;

        public ProblemVO ProblemVo
        {
            get { return _problemVo;}
            set { _problemVo = value; }
        }
        
        #endregion //Properties
        #region Constructors
        public WizardViewModel(IRegionManager regionManager)
        {
            WizardVo = new WizardVO();            

            _categoryBL = new CategoryBL();
            _categories = new ObservableCollection<CategoryVO>(_categoryBL.FindAll());

            _subCategoryBL = new SubCategoryBL();     
            _wizardBL = new WizardBL();     
            
            ProblemVo = new ProblemVO();
            
            _problemBl = new ProblemBL();            
        }

        #endregion //Constructors 

        public void ManageSave()
        {
            _problemBl.Save((_problemVo));
            _wizardBL.Save(_wizardVo);
        } 
    }
}
