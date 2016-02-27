﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLService.BL;
using CategoryModule.Views;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using Prism.Events;

namespace CategoryModule.ViewModels
{
    public class CategoryViewModel: ViewModelBase, ICategoryViewModel
    {        
        private readonly CategoryBL _categoryBL;

        #region Properties

        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }      
        #endregion //Properties
        #region Constructors

        public CategoryViewModel(ICategoryView view, CategoryBL categoryBL)
            : base(view)
        {
            _categoryBL = categoryBL;
            _categories = new ObservableCollection<Category>(_categoryBL.FindAll());            
        }
        #endregion //Constructors       
    }
}
