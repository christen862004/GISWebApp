using Microsoft.EntityFrameworkCore;

namespace GISWebApp.Models
{
    public class CompanyContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GISWebDB;Integrated Security=True;Encrypt=False");
        }
    }
}
