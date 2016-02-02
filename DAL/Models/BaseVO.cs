using DAL.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class BaseVO : IObjectWithState
    {
        public BaseVO()
        {
            CreatedDate = DateTime.Now;
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        
        [DataType(DataType.DateTime)]        
        public DateTime? ModifiedDate { get; set; }

        [NotMapped]
        public State State { get; set; }
    }
}
