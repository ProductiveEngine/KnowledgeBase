using System.Windows.Controls;
using KnolwdgeBase.Infrastructure;

namespace ModuleA
{
    /// <summary>
    /// Interaction logic for ContentA.xaml
    /// </summary>
    public partial class ContentAView : UserControl, IContentAView
    {
        public ContentAView(IContentAViewViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IContentAViewViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
