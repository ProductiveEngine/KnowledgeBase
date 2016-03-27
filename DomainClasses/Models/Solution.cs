using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Models
{
    [Table("Solutions")]
    public class Solution : Base.Base
    {
        [Key]
        public int SolutionId { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string Tags { get; set; }
        
        public float Rating { get; set; }

        public int ProblemID { get; set; }
        public virtual Problem Problem { get; set; }

        public virtual ICollection<Step> Steps { get; set; }
    }
}
