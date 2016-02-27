using System.Windows;
using System.Windows.Controls;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;

namespace CategoryModule.Views
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl, ICategoryView 
    {
        
        public CategoryView()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
          
        private void gridCategory_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //var _emp = e.Row.Item as Employee;
            Category cVO = e.Row.DataContext as Category;

            MessageBox.Show(string.Format("updated record:\n{0}\n{1}\n{2}",
                cVO.Title, cVO.Description, cVO.CreatedDate));
        }
    }
}
