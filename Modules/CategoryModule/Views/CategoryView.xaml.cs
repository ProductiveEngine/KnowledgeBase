using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.Models;
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
            // Only act on Commit
            if (e.EditAction == DataGridEditAction.Commit)
            {
                CategoryVO cVO = e.Row.DataContext as CategoryVO;
                //driver.Save();
            }
        }

        private void ScrollViewer_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            var cVO = e;
        }

        private void gridCategory_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox textBox = e.EditingElement as TextBox;
        }
    }
}
