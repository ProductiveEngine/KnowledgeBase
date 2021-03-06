﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Models
{
    [Table("SubCategories")]
    public class SubCategoryVO : Base.Base
    {
        [Key]
        public int SubCategoryID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual CategoryVO Category { get; set; }
        public virtual ICollection<ProblemVO> Problems { get; set; }        
    }
}
