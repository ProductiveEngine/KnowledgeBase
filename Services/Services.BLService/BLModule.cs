using BLService.BL;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace BLService
{
    public class BLModule : IModule
    {
        private IUnityContainer _container;

        public BLModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<CategoryBL>(new ContainerControlledLifetimeManager());
        }
    }
}
