using Microsoft.Practices.Unity;
using Prism.Modularity;
using Services.BLService.BL;

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
