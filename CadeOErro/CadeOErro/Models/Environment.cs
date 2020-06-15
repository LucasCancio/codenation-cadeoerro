using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Server.Models
{
    [Table("Environment")]
    public class Environment
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string description { get; set; }

        public virtual ICollection<Log> logs { get; set; }
    }
}
