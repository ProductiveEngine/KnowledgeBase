using System;
using System.Collections.ObjectModel;
using BLService.BL;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;

namespace KB.CategoryModule.ViewModels
{
    public class CategoryViewModel: ViewModelBase, ICategoryViewModel
    {        
        private readonly CategoryBL _categoryBL;
        
        #region Properties
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }      
        #endregion //Properties
        #region Constructors

        public CategoryViewModel(IRegionManager regionManager)            
        {
            _categoryBL = new CategoryBL();
            _categories = new ObservableCollection<Category>(_categoryBL.FindAll());            
        }
        #endregion //Constructors  

        public Boolean ManageSave(Category category)
        {
            return _categoryBL.Save(category);
        }

        public Boolean ManageDelete(Category category)
        {
            return _categoryBL.Remove(category.CategoryID);
        }
    }
}
