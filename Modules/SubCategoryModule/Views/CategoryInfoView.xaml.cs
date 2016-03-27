using System.Windows.Controls;
using SubCategoryModule.ViewModels;

namespace SubCategoryModule.Views
{
    /// <summary>
    /// Interaction logic for CategoryInfoView.xaml
    /// </summary>
    public partial class CategoryInfoView : UserControl
    {
        public CategoryInfoView(CategoryInfoViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
