using CadeOErro.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Server.Repositories
{
    public class EnvironmentRepository
    {
        private readonly CadeOErroContext _context;
        public EnvironmentRepository(CadeOErroContext context)
        {
            this._context = context;
        }
    }
}
