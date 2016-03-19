using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using SubCategoryModule.Views;

namespace KB.SubCategoryModule
{
    public class ModuleSubCateogryModule : ModuleBase
    {        
        public ModuleSubCateogryModule(IUnityContainer container, IRegionManager regionManager)
             : base(container, regionManager)
        {            
        }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(SubCategoryView));
        }

        protected override void RegisterTypes()
        {          
        }        
    }
}
