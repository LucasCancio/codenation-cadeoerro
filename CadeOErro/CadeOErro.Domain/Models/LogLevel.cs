﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadeOErro.Domain.Models
{
    [Table("LogLevel")]
    public class LogLevel
    {

        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string description { get; set; }

        public virtual ICollection<Log> logs { get; set; }

    }
}
