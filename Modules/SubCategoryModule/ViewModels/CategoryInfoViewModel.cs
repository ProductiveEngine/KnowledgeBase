using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Commands;
using Prism.Regions;

namespace SubCategoryModule.ViewModels
{
    public class CategoryInfoViewModel : ViewModelBase, INavigationAware
    {
        private IRegionNavigationJournal _journal;
                
        public DelegateCommand CancelCommand {get; private set; }

        public CategoryInfoViewModel()
        {
            CancelCommand = new DelegateCommand(Cancel);
        }

        private void Cancel()
        {
            _journal.GoBack();
        }


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
            var toCategoryTitle = ((Category) navigationContext.Parameters["To"]).Title;
            if (Title == toCategoryTitle)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
               
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
