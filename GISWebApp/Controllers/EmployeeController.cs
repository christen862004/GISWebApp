using GISWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GISWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext context = new CompanyContext();
        //show all instructor
        public IActionResult Index()
        {
            List<Employee> empList= context.Employees.ToList();
            return View("Index",empList);
        }
        //get instructor details
        //Details(int id)
    }
}
