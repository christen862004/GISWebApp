using GISWebApp.Models;
using GISWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

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
            int x = 10;
            //if(x>5 && x%2==0)
            //1)return View("Index");//View Index ,Model = null
            //3)return View();//View with the same action name "Index" ,Model Null
            //2)return View("Index",empList);//View Index ,Model type List<Employee>
            return View(empList); //View with the same action name "Index" ,Model List<Employee>
        }

        #region DEtails
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

        public IActionResult DetailsVM(int id)
        {
            //Step 1 :Collect data from different sourc3
            string Msg = "Hello";
            int Temp = 25;
            List<string> branches = new() {
                "Alex","Menia","Mansoura","Smart"
            };
            #region Simple Way
            //Employee? empMode = context.Employees
            //    .FirstOrDefault(e => e.Id == id);//get Employee
            //Department? deptModel = context.Departments //Get DEpartment 
            //    .FirstOrDefault(d => d.Id == empMode.DepartmentId);//Pk == Fks
            #endregion
            
            //Another Way
            Employee? empMode = context.Employees.Include(e=>e.Dept)
               .FirstOrDefault(e => e.Id == id);
            
            //Step 2 :Declare ViewModel
            EmpDepNAmeWithBrchTempMsgColorViewModel EmpVm = new();

            //Step 3 : Mapping get data from source set ViewModel
            EmpVm.EmpID = empMode.Id;
            EmpVm.EmpName = empMode.Name;
            EmpVm.DeptName = empMode.Dept.Name;
            EmpVm.Branches = branches;
            EmpVm.Message = Msg;
            EmpVm.Temp = Temp;
            EmpVm.Color = Temp < 25 ? "Blue" : "Red";
            //if (Temp < 25)
            //    EmpVm.Color = "blue";
            //else
            //    EmpVm.Color = "red";


            //Step 4 :Send  ViewModel to View
            return View("DetailsVM", EmpVm);
        }
        #endregion

    }
}
