using System;
using System.Data;
using System.Windows.Controls;
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

    }
}
