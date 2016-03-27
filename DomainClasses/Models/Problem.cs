using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Models
{
    [Table("Problems")]
    public class Problem : Base.Base
    {
        [Key]
        public int ProblemID { get; set; }
        
        [StringLength(500, MinimumLength = 3)]
        public string Tags { get; set; }

        public int? SubCategoryID { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
    }
}
