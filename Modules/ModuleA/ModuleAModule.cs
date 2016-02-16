using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _manager;

        public ModuleAModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }

        public void Initialize()
        {
            _container.RegisterType<IContentAView, ContentAView>();
            _container.RegisterType<IContentAViewViewModel, ContentAViewViewModel>();

            _manager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentAView));
        }
    }
}
