using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using SubCategoryModule.Navigation;
using SubCategoryModule.Views;

namespace SubCategoryModule
{
    class ModuleSubCateogryModule : ModuleBase//IModule
    {
        //private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _container;

        public ModuleSubCateogryModule(IUnityContainer container, IRegionManager regionManager)
             : base(container, regionManager)
        {
            //this._container = container;
            //this._regionManager = regionManager;
        }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(SubCategoryButton));
        }

        protected override void RegisterTypes()
        {
            //Container.RegisterType<SubCategoryView>();
            //Container.RegisterType<object, SubCategoryView>(typeof(SubCategoryView).FullName);
            //Container.RegisterType<object, CategoryInfoView>(typeof(CategoryInfoView).FullName);
            Container.RegisterTypeForNavigation<SubCategoryView>();
            Container.RegisterTypeForNavigation<CategoryInfoView>();

        }


        //public void Initialize()
        //{
        //    RegisterViewsAndServices();

        //    //Standard registration
        //    //var vm = _container.Resolve<ISubCategoryViewModel>();
        //    //_regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);
        //    //Navigation registration
        //    //_regionManager.RequestNavigate("ContentRegion", "SubCategoryView");

        //    _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof (SubCategoryButton));
        //}

        //protected void RegisterViewsAndServices()
        //{
        //    //Standard registration
        //    //_container.RegisterType<ISubCategoryViewModel, SubCategoryViewModel>();
        //    //_container.RegisterType<ISubCategoryView, SubCategoryView>();
        //    //Navigation Registration            
        //    _container.RegisterType(typeof(object),typeof(SubCategoryView), "SubCategoryView");
        //    _container.RegisterType(typeof (object), typeof (CategoryInfoView), "CategoryInfoView");            
        //    //_container.RegisterType<object, SubCategoryView>(typeof(SubCategoryView).FullName);
        //    //_container.RegisterType<object, CategoryInfoView>(typeof(CategoryInfoView).FullName);

        //    //_container.RegisterTypeForNavigation<SubCategoryView>();
        //    //_container.RegisterTypeForNavigation<CategoryInfoView>();
        //}
    }
}
