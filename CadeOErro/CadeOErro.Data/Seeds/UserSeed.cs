using CadeOErro.Domain.Models;
using System.Linq;

namespace CadeOErro.Data.Seeds
{
    public class UserSeed
    {
        private readonly CadeOErroContext _context;

        public UserSeed(CadeOErroContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if (_context.Users.Any())
                return;

            User u1 = new User
            {
                name="Lucas",
                role="admin",
                email="admin@gmail.com",
                password= "202cb962ac59075b964b07152d234b70",
                cpf= "20735259038"
            };
           
            _context.Users.Add(u1);
            _context.SaveChanges();
        }
    }
}
