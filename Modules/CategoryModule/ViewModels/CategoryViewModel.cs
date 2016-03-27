using System;
using System.Collections.ObjectModel;
using BLService.BL;
using CategoryModule.Views;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;

namespace CategoryModule.ViewModels
{
    public class CategoryViewModel: ViewModelBase, ICategoryViewModel, INavigationAware, IRegionMemberLifetime
    {        
        private readonly CategoryBL _categoryBL;

        //Naming View models convention-> View Name + "ViewModel"

        #region Properties
        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set
            {
                _pageViews = value;
                OnPropertyChanged("PageViews");
            }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }      
        #endregion //Properties
        #region Constructors

        public CategoryViewModel(ICategoryView view, CategoryBL categoryBL)
            : base(view)
        {
            _categoryBL = categoryBL;
            _categories = new ObservableCollection<Category>(_categoryBL.FindAll());            
        }
        #endregion //Constructors  

        public Boolean ManageSave(Category category)
        {  
            return _categoryBL.Save(category);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _pageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        //Each time tha this view is navigated to, i will get a new instance
        public bool KeepAlive { get { return false; } }
    }
}
