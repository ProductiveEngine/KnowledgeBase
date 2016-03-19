using System;
using System.Collections.ObjectModel;
using BLService.BL;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;

namespace KB.SubCategoryModule.ViewModels
{
    public class SubCategoryViewModel : ViewModelBase, ISubCategoryViewModel
    {        
        private readonly CategoryBL _categoryBl;
        private readonly SubCategoryBL _subCategoryBl;

        #region Properties       

        private string _selectedItem = "None";

        public string SelectedItem
        {
            get { return _selectedItem;}
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }
        private ObservableCollection<SubCategory> _subCategories;
        public ObservableCollection<SubCategory> SubCategories
        {
            get { return _subCategories; }
            set { _subCategories = value; }
        }

        #endregion //Properties
        #region Constructors

        public SubCategoryViewModel(IRegionManager regionManager)
        {            
            _subCategoryBl = new SubCategoryBL();            
            _subCategories = new ObservableCollection<SubCategory>(_subCategoryBl.FindAll());

            _categoryBl = new CategoryBL();
            _categories = new ObservableCollection<Category>(_categoryBl.FindAll());
        }
        #endregion //Constructors  
       
        public Boolean ManageSave(SubCategory subCategory)
        {
            bool ok = false;
            ok = _subCategoryBl.Save(subCategory);

            return ok;
        }      
    }
}

