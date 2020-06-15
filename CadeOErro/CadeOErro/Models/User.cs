﻿using System;
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
        public string password { get; set; }
        [Required]
        public string cpf { get; set; }
        public string token { get; set; }

        public bool active { get; set; }
        [Column( "created_date")]
        public DateTime createdDate { get; set; }

        [Column( "id_role")]
        public int idRole { get; set; }
        [ForeignKey("idRole")]
        public virtual Role role { get; set; }
        
    }
}
