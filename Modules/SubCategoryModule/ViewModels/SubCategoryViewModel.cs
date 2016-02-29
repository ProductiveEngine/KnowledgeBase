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
        private readonly SubCategoryBL _subCategoryBl;

        #region Properties

        private ObservableCollection<SubCategory> _subCategories;

        public ObservableCollection<SubCategory> SubCategories
        {
            get { return _subCategories; }
            set { _subCategories = value; }
        }
        #endregion //Properties
        #region Constructors

        public SubCategoryViewModel(ISubCategoryView view, SubCategoryBL subCategoryBL)
            : base(view)
        {
            _subCategoryBl = subCategoryBL;
            _subCategories = new ObservableCollection<SubCategory>(_subCategoryBl.FindAll());
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
