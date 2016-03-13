using System.Windows;
using System.Windows.Controls;
using BLService;
using CategoryModule;
using KnolwdgeBase.Infrastructure;
using KnolwdgeBase.Infrastructure.Prism;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using SubCategoryModule;

namespace KnoledgeBase
{
    public class Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();

            var regionManager = RegionManager.GetRegionManager((Shell));
            RegionManagerAware.SetRegionManagerAware(Shell, regionManager);

            App.Current.MainWindow = (Window) Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IShellViewModel, ShellViewModel>();

            Container.RegisterType<IShellService, ShellService>(new ContainerControlledLifetimeManager());
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();
            catalog.AddModule(typeof(BLModule));
            catalog.AddModule(typeof(ModuleCateogryModule));
            catalog.AddModule(typeof(ModuleSubCateogryModule));            
            //catalog.AddModule(typeof(PersonServiceModule));
            //catalog.AddModule(typeof(ModuleAModule));

            //catalog.AddModule(typeof(ServicesModule));
            //catalog.AddModule(typeof(ToolbarModule));
            //catalog.AddModule(typeof (PeopleModule));
            //catalog.AddModule(typeof(StatusBarModule));


            //catalog.AddModule(typeof(SubCatModule));            
            return catalog;
        }

        //protected override void ConfigureModuleCatalog()
        //{
        //    Type moduleAType = typeof (ModuleAModule);
        //    ModuleCatalog.AddModule(new ModuleInfo()
        //    {
        //        ModuleName = moduleAType.Name,
        //        ModuleType = moduleAType.AssemblyQualifiedName,
        //        InitializationMode = InitializationMode.WhenAvailable
        //    });

        //}

        //protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        //{
        //    IRegionBehaviorFactory behaviors = base.ConfigureDefaultRegionBehaviors();
        //    behaviors.AddIfMissing(RegionManagerAwareBehavior.BehaviorKey, typeof(RegionManagerAwareBehavior));

        //    return behaviors;
        //}
    }
}
