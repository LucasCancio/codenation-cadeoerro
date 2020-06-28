using System;

namespace CadeOErro.Server.DTOs
{
    public class UserDTO
    {
        public string email { get; set; }
        public string token { get; set; }
        public DateTime? expires { get; set; }
        public string role { get; set; }
    }
}
