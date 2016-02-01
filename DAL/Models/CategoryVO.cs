using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Categories")]
    public class CategoryVO : BaseVO
    {
        [Key]
        public int CategoryID { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<SubCategoryVO> SubCategories { get; set; }
    }
}
