using KB.Toolbar.Views;
using KnolwdgeBase.Infrastructure;

namespace KB.Toolbar.ViewModels
{
    public class ToolbarViewModel : ViewModelBase, IToolbarViewModel
    {
        public ToolbarViewModel(IToolbarView view)
            : base(view)
        {

        }
    }
}
