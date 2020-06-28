using CadeOErro.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CadeOErro.Server.Data
{
    public class CadeOErroContext : DbContext
    {
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogLevel> LogLevels { get; set; }
        public DbSet<User> Users { get; set; }

        public CadeOErroContext(DbContextOptions<CadeOErroContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
