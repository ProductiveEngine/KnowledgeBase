using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using KB.SubCategoryModule.ViewModels;

namespace KB.SubCategoryModule.Views
{    
    public partial class SubCategoryView : UserControl, ISubCategoryView
    {
        SubCategoryViewModel _cvm = null;
       
        public SubCategoryView(SubCategoryViewModel subCategoryViewModel)
        {
            InitializeComponent();
            DataContext = subCategoryViewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        private void GridSubCategory_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            bool ok = false;
                        
            SubCategory cat = e.Row.DataContext as SubCategory;
            _cvm = (SubCategoryViewModel)ViewModel;
            cat.ModifiedDate = DateTime.Now;

            ok = _cvm.ManageSave(cat);          
        }

        private void GridSubCategory_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
                            SubCategory subCat = row as SubCategory;
                            _cvm = (SubCategoryViewModel)ViewModel;

                            ok = _cvm.ManageDelete(subCat);
                        }                        
                    }
                    e.Handled = (result == MessageBoxResult.No);                    
                }
            }
        }
    }
}

//private void DriversDataGrid_PreviewDeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
//{
//    if (e.Command == DataGrid.DeleteCommand)
//    {
//        if (!(MessageBox.Show("Are you sure you want to delete?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
//        {
//            // Cancel Delete.
//            e.Handled = true;
//        }
//    }
//}
//private void Drivers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
//{
//    // Only Delete
//    if (e.Action == NotifyCollectionChangedAction.Remove)
//    {
//        foreach (FormulaOneDriver driver in e.OldItems)
//        {
//            driver.Delete();
//        }
//    }
//}