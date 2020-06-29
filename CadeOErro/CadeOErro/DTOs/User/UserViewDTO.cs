using System;

namespace CadeOErro.Server.DTOs.User
{
    public class UserViewDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string token { get; set; }
        public bool active { get; set; }
        public DateTime createdDate { get; set; }
        public string role { get; set; }
    }
}
