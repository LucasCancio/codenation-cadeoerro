using System;

namespace CadeOErro.Server.DTOs.Login
{
    public class AuthenticateDTO
    {
        public int idUser { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public DateTime? expiresAt { get; set; }
        public string role { get; set; }    
    }
}
