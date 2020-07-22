using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadeOErro.Domain.Models
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(255)]
        public string description { get; set; }
        public int frequency { get; set; }
        [MaxLength(255)]
        public string source { get; set; }
        public string stackTrace { get; set; }
        public bool filed { get; set; }
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

        public override bool Equals(object obj)
        {
            var log = (Log)obj;

            bool idsEquals = log.idEnvironment == this.idEnvironment && log.idLogLevel == this.idLogLevel;

            return idsEquals &&
                this.description.ToLower() == log.description.ToLower() &&
                this.source.ToLower() == log.source.ToLower() &&
                this.stackTrace.ToLower() == log.stackTrace.ToLower();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
