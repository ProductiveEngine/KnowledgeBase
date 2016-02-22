using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryModule.Views;
using DAL.Models;
using KB.BL;
using KnolwdgeBase.Infrastructure;
using Prism.Events;

namespace CategoryModule.ViewModels
{
    public class CategoryViewModel: ViewModelBase, ICategoryViewModel
    {
        private readonly CategoryBL _categoryBL;

        #region Properties

        private ObservableCollection<CategoryVO> _categories;

        public ObservableCollection<CategoryVO> Categories
        {
            get { return _categories;}
            set
            {
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }

        #endregion //Properties
        #region Constructors
        public CategoryViewModel(ICategoryView view, CategoryBL categoryBL)
            : base(view)
        {
            _categoryBL = categoryBL;
            _categories = new ObservableCollection<CategoryVO>(_categoryBL.FindAll());            
        }
        #endregion //Constructors       
    }
}
