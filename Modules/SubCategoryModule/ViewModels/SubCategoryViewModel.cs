using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using Services.BLService.BL;

namespace SubCategoryModule.ViewModels
{
    public class SubCategoryViewModel : ViewModelBase, ISubCategoryViewModel, INavigationAware, IConfirmNavigationRequest
    {
        private readonly IRegionManager _regionManager;
        private readonly CategoryBL _categoryBl;
        private readonly SubCategoryBL _subCategoryBl;

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
        private string _status;

        public string Status
        {
            get { return _status;}
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }            
        }
        public InteractionRequest<INotification> NotificationRequest { get; set; }
        public ICommand NotificationCommand { get; set; }

        public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; } 
        public ICommand ConfirmationCommand { get; set; }

        public InteractionRequest<INotification> CustomPopupRequest { get; set; }
        public ICommand CustomPopupCommand { get; set; }

        public ICommand SelectItemCommand { get; set; }

        public DelegateCommand<SubCategoryVO> CategoryInfoCommand { get; set; }

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

        //Standard registration
        //public SubCategoryViewModel(ISubCategoryView view, IRegionManager regionManager)
        //    : base(view)
        //Navigation registration
        public SubCategoryViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            _subCategoryBl = new SubCategoryBL();            
            _subCategories = new ObservableCollection<SubCategoryVO>(_subCategoryBl.FindAll());

            _categoryBl = new CategoryBL();
            _categories = new ObservableCollection<CategoryVO>(_categoryBl.FindAll());

            NotificationRequest = new InteractionRequest<INotification>();
            NotificationCommand = new DelegateCommand(RaiseNotification);

            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            ConfirmationCommand = new DelegateCommand(RaiseConfirmation);

            CustomPopupRequest = new InteractionRequest<INotification>();
            CustomPopupCommand = new DelegateCommand(RaiseCustomPopup);

            SelectItemCommand = new DelegateCommand<object[]>(SelectItem);

            CategoryInfoCommand = new DelegateCommand<SubCategoryVO>(CategoryInfo);
        }
        #endregion //Constructors  

        private void CategoryInfo(SubCategoryVO subcategory)
        {
            if (subcategory != null && subcategory.CategoryID > 0)
            {
                CategoryVO category = _categoryBl.GetAll().FirstOrDefault(x => x.CategoryID == subcategory.CategoryID);
                var parameters = new NavigationParameters();
                parameters.Add("To", category);
                _regionManager.RequestNavigate("ContentRegion", new Uri("CategoryInfoView", UriKind.Relative),
                    NavigationCompleted,parameters);

                //IRegion region = ...
                //region.RequestNavigate(newUri("MyView", UriKind.Relative));            
            }
        }

        private void NavigationCompleted(NavigationResult result)
        {
            
        }

        public Boolean ManageSave(SubCategoryVO subCategory)
        {
            bool ok = false;
            ok = _subCategoryBl.Save(subCategory);

            return ok;
        }

        void RaiseNotification()
        {
            NotificationRequest.Raise(new Notification { Title ="Notification", Content = "Notification Message"}, r=> Status = "Notified" );
        }

        void RaiseConfirmation()
        {
            ConfirmationRequest.Raise(new Confirmation {Title = "Confirmation", Content = "Confirmation Message"}, r => Status = r.Confirmed?"Confirmed":"Not Confirmed");
        }

        void RaiseCustomPopup()
        {
            CustomPopupRequest.Raise(new Notification { Title = "Custom Popup", Content = "Custom Popup Message" }, r => Status = "Good to go");
        }

        void SelectItem(object[] items)
        {
            if (items != null && items.Length > 0)
            {
                SelectedItem = ((SubCategoryVO) items.FirstOrDefault()).Title ;
            }
        }

        //NavigationContext
        //Navigation Services
        //URI
        //Parameters
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            //if (MessageBox.Show("Do you want to navigate?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
                continuationCallback(result);
            //}
        }
    }
}

//Navigation Journal works only with Region Navigation Services
//Not with view injection or view discovery

//View injection -> programmatically inject view
    //RegionManager.Region["Name"].Add(view,name)
    //IRegion.Add(view, name)
    //Activate/Deactivate views

//View discovery
    //Views are added automatically
    //RegionManager.RegisterViewWithRegion(name,type)
    //No excplicit control
