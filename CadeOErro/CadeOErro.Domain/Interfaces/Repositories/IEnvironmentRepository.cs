using CadeOErro.Domain.Models;
using System.Collections.Generic;

namespace CadeOErro.Domain.Interfaces.Repositories
{
    public interface IEnvironmentRepository
    {
        List<Environment> GetAll();
        Environment FindById(int id);
        Environment Create(Environment environment);
        void Delete(int id);
    }
}
