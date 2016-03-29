using System;
using System.Windows;
using System.Windows.Controls;
using CategoryModule.ViewModels;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;

namespace CategoryModule.Views
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl, ICategoryView 
    {
        CategoryViewModel _cvm = null;

        public CategoryView()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
          
        private void GridCategory_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            bool ok = false;

            //var _emp = e.Row.Item as Employee;
            CategoryVO cat = e.Row.DataContext as CategoryVO;
            _cvm = (CategoryViewModel)ViewModel;
            cat.ModifiedDate = DateTime.Now;

            ok = _cvm.ManageSave(cat);
            
            if (ok)
            {                
                MessageBox.Show(Properties.Resources.SaveSuccess,
                    Properties.Resources.SaveCategoryResult,
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(Properties.Resources.SaveSuccess,
                    Properties.Resources.SaveCategoryResult,
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }            
        }
    }
}
