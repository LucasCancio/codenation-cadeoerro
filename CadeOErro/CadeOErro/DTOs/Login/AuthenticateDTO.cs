using System;

namespace CadeOErro.Server.DTOs.Login
{
    public class AuthenticateDTO
    {
        public string email { get; set; }
        public string token { get; set; }
        public DateTime? expiresAt { get; set; }
        public string role { get; set; }
    }
}
