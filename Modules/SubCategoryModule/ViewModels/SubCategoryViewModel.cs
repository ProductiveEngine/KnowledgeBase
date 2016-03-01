using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLService.BL;
using DomainClasses.Models;
using KnolwdgeBase.Infrastructure;
using SubCategoryModule.Views;

namespace SubCategoryModule.ViewModels
{
    public class SubCategoryViewModel : ViewModelBase, ISubCategoryViewModel
    {
        private readonly CategoryBL _categoryBl;
        private readonly SubCategoryBL _subCategoryBl;

        #region Properties
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }
        private ObservableCollection<SubCategory> _subCategories;
        public ObservableCollection<SubCategory> SubCategories
        {
            get { return _subCategories; }
            set { _subCategories = value; }
        }
        #endregion //Properties
        #region Constructors

        public SubCategoryViewModel(ISubCategoryView view)
            : base(view)
        {
            _subCategoryBl = new SubCategoryBL();            
            _subCategories = new ObservableCollection<SubCategory>(_subCategoryBl.FindAll());

            _categoryBl = new CategoryBL();
            _categories = new ObservableCollection<Category>(_categoryBl.FindAll());
        }
        #endregion //Constructors  

        public Boolean ManageSave(SubCategory subCategory)
        {
            bool ok = false;
            ok = _subCategoryBl.Save(subCategory);

            return ok;
        }

    }
}
