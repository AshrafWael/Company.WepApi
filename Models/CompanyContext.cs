using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class CompanyContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-TT2AFSL\\SQLEXPRESS; Database =APICompanyDataBase;Integrated Security =true ;TrustServerCertificate =true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
