using System;
using System.Windows.Controls;
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

            Category cat = e.Row.DataContext as Category;
            _cvm = (CategoryViewModel) ViewModel;
            cat.ModifiedDate = DateTime.Now;

            ok = _cvm.ManageSave(cat);

        }

    }
}
