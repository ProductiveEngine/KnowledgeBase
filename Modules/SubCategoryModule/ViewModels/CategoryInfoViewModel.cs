using System;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Regions;

namespace SubCategoryModule.ViewModels
{
    public class CategoryInfoViewModel : ViewModelBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title;}
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Category category = navigationContext.Parameters["To"] as Category;

            if (category != null)
            {
                Title = category.Title;
                Description = category.Description;
            }
            else
            {
                Title = "No Category info provided";
            }

        }
    }
}
