using KB.StatusBar.ViewModels;
using KB.StatusBar.Views;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace KB.StatusBar
{
    public class StatusBarModule : ModuleBase
    {
        public StatusBarModule(IUnityContainer container, IRegionManager regionManager) : base(container, regionManager)
        {
        }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion, typeof(StatusBarView));
        }

        protected override void RegisterTypes()
        {
            
        }
    }
}
