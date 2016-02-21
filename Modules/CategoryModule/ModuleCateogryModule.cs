using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryModule.ViewModels;
using CategoryModule.Views;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace CategoryModule
{
    public class ModuleCateogryModule: IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public ModuleCateogryModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            var vm = _container.Resolve<ICategoryViewModel>();
            _regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<ICategoryViewModel, CategoryViewModel>();
            _container.RegisterType<ICategoryView, CategoryView>();
        }
    }
}
