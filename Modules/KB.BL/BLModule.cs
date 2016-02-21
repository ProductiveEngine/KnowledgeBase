using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace KB.BL
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
