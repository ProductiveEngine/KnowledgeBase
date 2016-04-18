using System;
using System.Collections.ObjectModel;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;
using Services.BLService.BL;

namespace KB.CategoryModule.ViewModels
{
    public class CategoryViewModel: ViewModelBase, ICategoryViewModel
    {        
        private readonly CategoryBL _categoryBL;
        
        #region Properties
        private ObservableCollection<CategoryVO> _categories;
        public ObservableCollection<CategoryVO> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }      
        #endregion //Properties
        #region Constructors
        public CategoryViewModel(IRegionManager regionManager)            
        {
            _categoryBL = new CategoryBL();
            _categories = new ObservableCollection<CategoryVO>(_categoryBL.FindAll());            
        }
        #endregion //Constructors  

        public Boolean ManageSave(CategoryVO category)
        {
            return _categoryBL.Save(category);
        }

        public Boolean ManageDelete(CategoryVO category)
        {
            return _categoryBL.Remove(category.CategoryID);
        }
    }
}
