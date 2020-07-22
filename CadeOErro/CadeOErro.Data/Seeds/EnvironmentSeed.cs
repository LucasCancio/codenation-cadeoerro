
using CadeOErro.Domain.Models;
using System.Linq;

namespace CadeOErro.Data.Seeds
{
    public class EnvironmentSeed
    {
        private readonly CadeOErroContext _context;

        public EnvironmentSeed(CadeOErroContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if (_context.Environments.Any())
                return;

            Environment env1 = new Environment
            {
                description = "Desenvolvimento",
                shortName = "dev"
            };
            Environment env2 = new Environment
            {
                description = "Homologação",
                shortName = "homolog"
            };
            Environment env3 = new Environment
            {
                description = "Produção",
                shortName = "prod"
            };

            _context.Environments.AddRange(env1, env2, env3);
            _context.SaveChanges();
        }
    }
}
