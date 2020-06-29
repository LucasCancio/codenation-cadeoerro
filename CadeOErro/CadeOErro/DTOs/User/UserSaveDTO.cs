namespace CadeOErro.Server.DTOs.User
{
    public class UserSaveDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string cpf { get; set; }
        public string token { get; set; }
    }
}
