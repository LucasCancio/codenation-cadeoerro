using System;

namespace CadeOErro.Server.DTOs.User
{
    public class UserViewDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public DateTime createdDate { get; set; }
        public string role { get; set; }
    }
}
