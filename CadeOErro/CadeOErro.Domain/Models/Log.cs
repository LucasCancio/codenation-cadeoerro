using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Domain.Models
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public int frequency { get; set; }
        [Required]
        public string source { get; set; }
        [Required]
        public string stackTrace { get; set; }
        public int status { get; set; }
        [Column("filed_date")]
        public DateTime filedDate { get; set; }
        [Column("created_date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdDate { get; set; } = DateTime.UtcNow;


        [Column("id_user")]
        public int idUser { get; set; }
        [ForeignKey("idUser")]
        public virtual User user { get; set; }


        [Column("id_environment")]
        public int idEnvironment { get; set; }
        [ForeignKey("idEnvironment")]
        public virtual Environment environment { get; set; }

        [Column("id_log_level")]
        public int idLogLevel { get; set; }
        [ForeignKey("idLogLevel")]
        public virtual LogLevel logLevel { get; set; }




    }
}
