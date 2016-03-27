using System.Windows.Controls;
using KnolwdgeBase.Infrastructure;

namespace KB.Toolbar.Views
{
    /// <summary>
    /// Interaction logic for ToolbarView.xaml
    /// </summary>
    public partial class ToolbarView : UserControl, IToolbarView
    {
        public ToolbarView()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
