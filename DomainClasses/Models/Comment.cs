using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Models
{
    [Table("Comments")]
    public class Comment : Base.Base
    {
        [Key]
        public int CommentID { get; set; }

        public int? StepID { get; set; }
        public virtual Step Step { get; set; }
    }
}
