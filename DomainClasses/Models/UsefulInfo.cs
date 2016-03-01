﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainClasses.Base;

namespace DomainClasses.Models
{
    [Table("UsefulInfos")]
    public class UsefulInfo : Base.Base
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
        public virtual Problem Problem { get; set; }
    }

    public enum ProgamingLanguage
    {
        CSharp,
        Java,
        Javascript
    }
}