using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadeOErro.Domain.Models
{
    [Table("Environment")]
    public class Environment
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column("short_name")]
        [MaxLength(10)]
        public string shortName { get; set; }
        [Required]
        [MaxLength(50)]
        public string description { get; set; }

        public virtual ICollection<Log> logs { get; set; }


        
    }
}
