using KnolwdgeBase.Infrastructure;
using KnolwdgeBase.Infrastructure.Prism;
using Prism.Commands;
using Prism.Regions;

namespace KnoledgeBase
{
    public class ShellViewModel : ViewModelBase, IShellViewModel, IRegionManagerAware
    {
        
        private readonly IShellService _service;

        public DelegateCommand<string> OpenShellCommand { get; private set; }
        public DelegateCommand<object> NavigateCommand { get; private set; }
        public DelegateCommand<object> AboutCommand { get; private set; }

        //IRegionManager -> Singleton
        public ShellViewModel(  IShellService service)
        {            
            _service = service;

            OpenShellCommand = new DelegateCommand<string>(OpenShell);
            NavigateCommand = new DelegateCommand<object>(Navigate);
            GlobalCommands.NavigateCommand.RegisterCommand(NavigateCommand);

            AboutCommand = new DelegateCommand<object>(OpenAboutDialog);
        }

        void OpenShell(string viewName)
        {
            _service.ShowShell(viewName);
        }

        private void OpenAboutDialog(object navigatePath)
        {
            About about = new About();
            about.ShowDialog();
        }

        //void Navigate(string viewName)
        //{
        //    _regionManager.RequestNavigate(KnownRegionNames.ContentRegion, viewName);
        //}
        private void Navigate(object navigatePath)
        {
            if (navigatePath != null)
            {
                RegionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath.ToString(), NavigateComplete);
            }
        }

        private void NavigateComplete(NavigationResult result)
        {
            //MessageBox.Show(String.Format("Navigation to {0} complete.", result.Context.Uri));
        }

        public IRegionManager RegionManager { get; set; }
    }
}
