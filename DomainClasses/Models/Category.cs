using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Models
{
    [Table("Categories")]
    public class CategoryVO : Base.Base, IDataErrorInfo
    {
        [Key]
        public int CategoryID { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<SubCategoryVO> SubCategories { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case "Title":
                        if (string.IsNullOrEmpty(Title))
                        {
                            error = "Title required";
                        }                                           
                        break;
                }
                Error = error;
                return (Error);
            }
        }
        
        private string _Error;
        [NotMapped]
        public string Error
        {
            get { return _Error; }
            private set
            {
                _Error = value;
                OnPropertyChanged("Error");
            }
        }
    }
}
