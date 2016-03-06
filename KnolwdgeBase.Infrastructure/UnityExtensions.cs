using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace KnolwdgeBase.Infrastructure
{
    public static class UnityExtensions
    {
        public static void RegisterTypeForNavigation<T>(this IUnityContainer container)
        {
            container.RegisterType(typeof (Object), typeof (T), typeof (T).FullName);
        }
    }
}
