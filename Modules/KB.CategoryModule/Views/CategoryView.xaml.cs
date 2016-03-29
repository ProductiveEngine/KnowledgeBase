using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DomainClasses.Models;
using KB.CategoryModule.ViewModels;
using KnolwdgeBase.Infrastructure;

namespace KB.CategoryModule.Views
{    
    public partial class CategoryView : UserControl, ICategoryView 
    {
        CategoryViewModel _cvm = null;

        public CategoryView(CategoryViewModel categoryViewModel)
        {
            InitializeComponent();
            DataContext = categoryViewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        private void GridCategory_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            bool ok = false;

            CategoryVO cat = e.Row.DataContext as CategoryVO;
            _cvm = (CategoryViewModel) ViewModel;
            cat.ModifiedDate = DateTime.Now;

            ok = _cvm.ManageSave(cat);          
        }

        private void GridCategory_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            bool ok = false;
            DataGrid dg = sender as DataGrid;

            if (dg != null)
            {
                DataGridRow dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                if (e.Key == Key.Delete && !dgr.IsEditing)
                {
                    // User is attempting to delete the row
                    var result = MessageBox.Show(
                        "About to delete the current row.\n\nProceed?",
                        "Delete",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question,
                        MessageBoxResult.No);

                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in dg.SelectedItems)
                        {
                            CategoryVO cat = row as CategoryVO;
                            _cvm = (CategoryViewModel)ViewModel;

                            ok = _cvm.ManageDelete(cat);

                            if (!ok)
                            {
                                dg.Items.Refresh();
                            }
                        }
                    }
                    e.Handled = (result == MessageBoxResult.No);
                }
            }
        }
    }
}
