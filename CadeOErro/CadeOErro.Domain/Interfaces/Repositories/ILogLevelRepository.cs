using CadeOErro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Domain.Interfaces.Repositories
{
   public interface ILogLevelRepository
    {
        List<LogLevel> GetAll();
        LogLevel FindById(int id);
        LogLevel Create(LogLevel logLevel);
        void Delete(int id);
    }
}
