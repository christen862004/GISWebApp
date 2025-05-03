using Microsoft.EntityFrameworkCore;

namespace GISWebApp.Models
{
    public class CompanyContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserAccount> Users { get; set; }
        //compatibitliy
        public CompanyContext() : base()
        {

        }


        public CompanyContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=.;Initial Catalog=GISWebDB;Integrated Security=True;Encrypt=False");
        }
    }
}
