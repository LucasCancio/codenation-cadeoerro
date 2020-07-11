using CadeOErro.Server.Util.Validators;
using System.ComponentModel.DataAnnotations;

namespace CadeOErro.Server.DTOs.User
{
    public class UserUpdateDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [RoleValidator]
        public string role { get; set; }
    }
}
