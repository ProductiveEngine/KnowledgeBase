using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("UsefulInfos")]
    public class UsefulInfoVO : BaseVO
    {
        [Key]
        public int UsefulInfoID { get; set; }

        public ProgamingLanguage ProgamingLang { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [DataType(DataType.Url)]
        public string URL { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        public int? ProblemID { get; set; }
        public virtual ProblemVO Problem { get; set; }
    }

    public enum ProgamingLanguage
    {
        CSharp,
        Java,
        Javascript
    }
}
