using CadeOErro.Domain.Util.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Domain.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        private string _name;
        [Required]
        public string name { get { return _name; } set { _name = value.ToFirstLetterUpper(); } }
        [Required]
        public string password { get; set; }
        [Required]
        [MaxLength(11)]
        public string cpf { get; set; }
        [Column("created_date")]
        public DateTime createdDate { get; set; }
        public string role { get; set; }



    }
}
