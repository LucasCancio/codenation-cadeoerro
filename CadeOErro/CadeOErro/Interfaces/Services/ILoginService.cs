using CadeOErro.Server.DTOs;
using CadeOErro.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Services
{
    public interface ILoginService
    {
       Task<UserDTO> Logon(string email, string password);
    }
}
