using CadeOErro.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeOErro.Server.Models
{
    public class CadeOErroContext : DbContext
    {
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogLevel> LogLevels { get; set; }
        public DbSet<Role> Roles { get; set; }
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
