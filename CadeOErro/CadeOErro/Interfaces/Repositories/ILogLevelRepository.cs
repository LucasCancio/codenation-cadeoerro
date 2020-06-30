using CadeOErro.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Server.Interfaces.Repositories
{
   public interface ILogLevelRepository
    {
        List<LogLevel> GetAll();
        LogLevel FindById(int id);
        LogLevel Create(LogLevel logLevel);
        void Delete(int id);
    }
}
