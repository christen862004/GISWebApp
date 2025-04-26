using GISWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GISWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext context = new CompanyContext();
        
        //constructore class C# default parameter less constructor
        public  EmployeeController()
        {
                
        }

        //show all instructor
        public IActionResult Index()
        {
            List<Employee> empList= context.Employees.ToList();

            return View("Index",empList);
        }
        //get instructor details
        public IActionResult Details(int id)
        {
            //logic
            string Msg = "Hello";

            int Temp = 25;
            
            List<string> branches = new() { 
                "Alex","Menia","Mansoura","Smart"
            };
            //Extra Info
            ViewData["Message"] = "Hello"; //Send Data From Action to View
            ViewData["Temp"] = Temp;
            ViewData["Brch"] = branches;
            

            ViewBag.Color = "Red";//override
            ViewData["Color"] = "blue";

            //Model 
            Employee empMode = context.Employees.FirstOrDefault(e=>e.Id== id);

            return View("Details", empMode);
        }
    }
}
