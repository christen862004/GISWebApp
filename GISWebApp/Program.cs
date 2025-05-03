using GISWebApp.Filtters;
using GISWebApp.Models;
using GISWebApp.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

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
            //Filtter global Scope
            builder.Services.AddControllersWithViews();
                //options=> options.Filters.Add(new HandelErrorAttribute()));
            
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);//wait time close
            });

            builder.Services.AddDbContext<CompanyContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            
            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            //Custom servic need to declare  ,and need to register ( dispose )
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            //------------------------------------------
            var app = builder.Build();
            #region Custom Pipline
            //app.Use(async (httpContext, next) => {
            //   await httpContext.Response.WriteAsync("1) Middleware 1 \n");//
            //   await next.Invoke();//-->2
            //   //await httpContext.Response.WriteAsync("1-1) Middleware 1-1 \n");//


            //});
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("2) Middleware 2 \n");//--
            //    await next.Invoke();//-->3
            //    await httpContext.Response.WriteAsync("2-2) Middleware 2-2 \n");//--

            //});
            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3) Terminate \n");//finsin

            //});
            ////unreachable middlew
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("2) Middleware 2 ---------------------\n");
            //    await next.Invoke();
            //});
            #endregion
            #region Configure the HTTP request pipeline. Day 3 Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();//Seceuity (Map)

            app.UseSession();//application understand Session(w/R)

            //app.UseAuthentication();//default midleware
            
            app.UseAuthorization();//role
            #region Custom Route
            //Stafff ddefine & execute
            //naming convention route MVC
            //app.MapControllerRoute("Rout1", "1r/{age:int:range(20,60)}/{name?}",//constraint
            //    new { controller = "Route", action = "Method1" });
            //r/MEthod1
            //r/MEthod2

            //app.MapControllerRoute("Rout1", "{controller}/{action}/{id?}",//constraint
            //    new { controller = "Route", action = "Method1" });

            //app.MapControllerRoute("Rout2", "r2",
            //  new { controller = "Route", action = "Method2" });
            #endregion
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");//the least one
            
            #endregion

            app.Run();
        }
    }
}
