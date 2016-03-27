using System;
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
