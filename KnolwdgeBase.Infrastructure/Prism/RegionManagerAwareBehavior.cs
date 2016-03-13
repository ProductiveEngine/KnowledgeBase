using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Regions;

namespace KnolwdgeBase.Infrastructure.Prism
{
    public class RegionManagerAwareBehavior : RegionBehavior
    {
        public const string BehaviorKey = "RegionMangerAwareBehavior";

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    IRegionManager regionManager = Region.RegionManager;
                    FrameworkElement element = item as FrameworkElement;
                    if (element != null)
                    {
                        IRegionManager scopedRegionManager = element.GetValue(RegionManager.RegionManagerProperty) as IRegionManager;

                        if (scopedRegionManager != null)
                        {
                            regionManager = scopedRegionManager;
                        }
                    }
                    InvokeOnRegionManagerAwareElement(item, x=> x.RegionManager = regionManager);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = null);
                }
            }
        }

        static void InvokeOnRegionManagerAwareElement(object item, Action<IRegionManagerAware> invocation)
        {
            var rmAwareItem = item as IRegionManagerAware;

            if (rmAwareItem != null)
            {
                invocation(rmAwareItem);
            }

            var frameworkElement = item as FrameworkElement;

            if(frameworkElement != null)
            {
                IRegionManagerAware rmAwareDataContext = frameworkElement.DataContext as IRegionManagerAware;

                if (rmAwareDataContext != null)
                {
                    var framworkElementParent = frameworkElement.Parent as FrameworkElement;

                    if (framworkElementParent != null)
                    {
                        var rmAwareDataContextParent = framworkElementParent.DataContext as IRegionManagerAware;

                        if (rmAwareDataContextParent != null)
                        {
                            if (rmAwareDataContext == rmAwareDataContextParent)
                            {
                                return;
                            }
                        }
                    }

                    invocation(rmAwareDataContext);
                }
                
            }
        }
    }
}
