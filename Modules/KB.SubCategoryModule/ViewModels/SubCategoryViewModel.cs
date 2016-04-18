using System;
using System.Collections.ObjectModel;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;
using Services.BLService.BL;

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

        private ObservableCollection<CategoryVO> _categories;
        public ObservableCollection<CategoryVO> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }
        private ObservableCollection<SubCategoryVO> _subCategories;
        public ObservableCollection<SubCategoryVO> SubCategories
        {
            get { return _subCategories; }
            set { _subCategories = value; }
        }

        #endregion //Properties
        #region Constructors

        public SubCategoryViewModel(IRegionManager regionManager)
        {            
            _subCategoryBl = new SubCategoryBL();            
            _subCategories = new ObservableCollection<SubCategoryVO>(_subCategoryBl.FindAll());

            _categoryBl = new CategoryBL();
            _categories = new ObservableCollection<CategoryVO>(_categoryBl.FindAll());
        }
        #endregion //Constructors  
       
        public Boolean ManageSave(SubCategoryVO subCategory)
        {
            bool ok = false;
            ok = _subCategoryBl.Save(subCategory);

            return ok;
        }

        public Boolean ManageDelete(SubCategoryVO subCategory)
        {
            bool ok = false;
            ok = _subCategoryBl.Remove(subCategory.SubCategoryID);

            return ok;
        }
    }
}

