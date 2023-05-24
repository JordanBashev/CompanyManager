using CompanyManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Database
{
    public class CompanyManagerContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public CompanyManagerContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamToProject> TeamToProject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration["connectionString:DefaultConnection"]);

        }
    }
}
