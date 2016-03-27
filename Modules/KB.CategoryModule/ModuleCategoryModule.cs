using KB.CategoryModule.Views;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace KB.CategoryModule
{
    public class ModuleCateogryModule : ModuleBase
    {

        public ModuleCateogryModule(IUnityContainer container, IRegionManager regionManager) 
            : base(container, regionManager)
        {
        }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(CategoryView));            
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<CategoryView>();            
        }             
    }
}
