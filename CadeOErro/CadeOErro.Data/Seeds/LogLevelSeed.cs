using CadeOErro.Domain.Models;
using System.Linq;

namespace CadeOErro.Data.Seeds
{
    public class LogLevelSeed
    {
        private readonly CadeOErroContext _context;

        public LogLevelSeed(CadeOErroContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if (_context.LogLevels.Any())
                return;

            LogLevel lvl1 = new LogLevel
            {
                description = "error"
            };
            LogLevel lvl2 = new LogLevel
            {
                description = "warning"
            };
            LogLevel lvl3 = new LogLevel
            {
                description = "debug"
            };
            LogLevel lvl4 = new LogLevel
            {
                description = "info"
            };

            _context.LogLevels.AddRange(lvl1, lvl2, lvl3,lvl4);
            _context.SaveChanges();
        }
    }
}
