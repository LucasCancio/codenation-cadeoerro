using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Server.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [MaxLength(11)]
        public string cpf { get; set; }
        [Column("created_date")]
        public DateTime createdDate { get; set; }

        private string _role;
        public string role
        {
            get { return _role; }
            set { _role = ValidateRole(value); }
        }

        private string ValidateRole(string role)
        {
            role = role.ToLower();
            if (role != "admin" || role != "user") role = "user";
            return role;
        }

    }
}
