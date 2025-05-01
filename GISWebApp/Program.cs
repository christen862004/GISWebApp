using GISWebApp.Models;
using GISWebApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GISWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Built in service already register (122)
            //built in service need to register (optial service)
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);//wait time close
            });

            builder.Services.AddDbContext<CompanyContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            //Custom servic need to declare  ,and need to register ( dispose )
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            //------------------------------------------
            var app = builder.Build();

            #region Configure the HTTP request pipeline. Day 3 Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseSession();//application understand Session(w/R)

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            
            app.Run();
        }
    }
}
