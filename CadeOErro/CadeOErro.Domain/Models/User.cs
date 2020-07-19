using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadeOErro.Domain.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [MaxLength(50)]
        public string password { get; set; }
        [Required]
        [MaxLength(11)]
        public string cpf { get; set; }
        [Column("created_date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        public string role { get; set; }


    }
}
