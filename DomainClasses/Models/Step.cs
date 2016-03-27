﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Models
{
    [Table("Steps")]
    public class Step : Base.Base
    {
        [Key]
        public int StepID { get; set; }
        
        public byte Sequence { get; set; }

        public int? SolutionID { get; set; }
        public virtual Solution Solution { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
