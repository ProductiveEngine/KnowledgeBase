using KB.People.ViewModels;
using KB.People.Views;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace KB.People
{
    public class PeopleModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public PeopleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();
            //----------------------
            //var vm = _container.Resolve<IPersonViewModel>();
            //_regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);
            //----------------------
            //#################################
            //IRegion region = _regionManager.Regions[RegionNames.ContentRegion];

            //var vm = _container.Resolve<IPersonViewModel>();
            //vm.CreatePerson("Bob", "Smith");

            //region.Add(vm.View);
            //region.Activate(vm.View);

            //var vm2 = _container.Resolve<IPersonViewModel>();
            //vm2.CreatePerson("Karl", "Sums");
            //region.Add(vm2.View);

            //var vm3 = _container.Resolve<IPersonViewModel>();
            //vm3.CreatePerson("Jeff", "Lock");
            //region.Add(vm3.View);
            //#################################
            var vm = this._container.Resolve<IPersonMasterViewModel>();
            _regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);

            _regionManager.RegisterViewWithRegion("PersonDetailsRegion", typeof (PersonDetailsView));
        }

        protected void RegisterViewsAndServices()
        {
            //_container.RegisterType<IPersonViewModel, PersonViewModel>();
            //_container.RegisterType<IPersonView, PersonView>();

            _container.RegisterType<IPersonMasterViewModel, PersonMasterViewModel>();
            _container.RegisterType<IPersonMasterView, PersonMasterView>();
            _container.RegisterType<IPersonDetailsView, PersonDetailsView>();
            _container.RegisterType<IPersonDetailsViewModel, PersonDetailsViewModel>();
        }
    }
}