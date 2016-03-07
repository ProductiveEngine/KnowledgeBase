using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KnolwdgeBase.Infrastructure;
using Prism.Commands;
using Prism.Regions;

namespace KnoledgeBase
{
    public class ShellViewModel : ViewModelBase, IShellViewModel
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<object> NavigateCommand { get; private set; }

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<object>(Navigate);
            GlobalCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }

        private void Navigate(object navigatePath)
        {
            if (navigatePath != null)
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath.ToString(), NavigateComplete);
            }
        }

        private void NavigateComplete(NavigationResult result)
        {
            //MessageBox.Show(String.Format("Navigation to {0} complete.", result.Context.Uri));
        }
    }
}
