using DevFreela.Core.Entities;

using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DevFreela;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Multi Subnet Failover=False");

//            //optionsBuilder.UseSqlServer(@"Server = DESKTOP - 12345\\SQLEXPRESS; Database = DevFreela; Integrated Security = True; trustServerCertificate = true");

//        }

//    }
//}
