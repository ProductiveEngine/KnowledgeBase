using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Comments")]
    public class CommentVO : BaseVO
    {
        [Key]
        public int CommentID { get; set; }

        public int? StepID { get; set; }
        public virtual StepVO Step { get; set; }
    }
}
