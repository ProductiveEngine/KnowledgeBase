using KB.StatusBar.ViewModels;
using KB.StatusBar.Views;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace KB.StatusBar
{
    public class StatusBarModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public StatusBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            var vm = _container.Resolve<IStatusBarViewModel>();
            _regionManager.Regions[RegionNames.StatusBarRegion].Add(vm.View);
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IStatusBarViewModel, StatusBarViewModel>();
            _container.RegisterType<IStatusBarView, StatusBarView>();
        }
    }
}
