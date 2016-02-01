﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Steps")]
    public class StepVO : BaseVO
    {
        [Key]
        public int StepID { get; set; }
        
        public byte Sequence { get; set; }

        public int? SolutionID { get; set; }
        public virtual SolutionVO Solution { get; set; }

        public virtual ICollection<CommentVO> Comments { get; set; }
    }
}
