using KB.SubCategoryModule.Views;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Regions;

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
            Container.RegisterTypeForNavigation<SubCategoryView>();
        }        
    }
}
