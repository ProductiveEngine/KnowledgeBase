using KB.PaSModule.Views;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace KB.PaSModule
{
    public class ModulePaSModule : ModuleBase
    {
        public ModulePaSModule(IUnityContainer container, IRegionManager regionManager) : base(container, regionManager)
        {
        }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(PaSView));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<PaSView>();
        }
    }
}
