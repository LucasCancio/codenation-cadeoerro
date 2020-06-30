using CadeOErro.Server.DTOs.Login;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface ILoginService
    {
       AuthenticateDTO Authenticate(string email, string password);
    }
}
