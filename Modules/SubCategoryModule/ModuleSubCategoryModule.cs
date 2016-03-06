using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using SubCategoryModule.Views;

namespace SubCategoryModule
{
    public class ModuleSubCateogryModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public ModuleSubCateogryModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            //Standard registration
            //var vm = _container.Resolve<ISubCategoryViewModel>();
            //_regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);
            //Navigation registration
            _regionManager.RequestNavigate("ContentRegion", "SubCategoryView");
        }

        protected void RegisterViewsAndServices()
        {
            //Standard registration
            //_container.RegisterType<ISubCategoryViewModel, SubCategoryViewModel>();
            //_container.RegisterType<ISubCategoryView, SubCategoryView>();
            //Navigation Registration            
            _container.RegisterType(typeof(object),typeof(SubCategoryView), "SubCategoryView");
            _container.RegisterType(typeof (object), typeof (CategoryInfoView), "CategoryInfoView");
            //_container.RegisterType<object, SubCategoryView>(typeof(SubCategoryView).FullName);
            //_container.RegisterType<object, CategoryInfoView>(typeof(CategoryInfoView).FullName);

            //_container.RegisterTypeForNavigation<SubCategoryView>();
            //_container.RegisterTypeForNavigation<CategoryInfoView>();
        }
    }
}
