using GISWebApp.Models;
using GISWebApp.Repository;
using GISWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;

namespace GISWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        //Employee/new
        //DIP
        IEmployeeRepository EmpRepo;
        IDepartmentRepository DeptRepo;
        //constructore class C# default parameter less constructor
        //EmployeeController empConte=new EmployeeController()
        public EmployeeController
            (IEmployeeRepository _empRepo, IDepartmentRepository _deptRepo)
        {
            EmpRepo = _empRepo;
            DeptRepo = _deptRepo;
            
        }

        //show all instructor
        public IActionResult Index()
        {
            
            List<Employee> empList = EmpRepo.GetAll();
            int x = 10;
            //if(x>5 && x%2==0)
            //1)return View("Index");//View Index ,Model = null
            //3)return View();//View with the same action name "Index" ,Model Null
            //2)return View("Index",empList);//View Index ,Model type List<Employee>
            return View("Index",empList); //View with the same action name "Index" ,Model List<Employee>
        }

        public IActionResult CheckSalary(int Salary,int DepartmentId)
        {

            //remote execute Db
            if (Salary > 6000 && DepartmentId==1)
                return Json(true);
            else if(Salary>8000 && DepartmentId==2)
                return Json(true);
            else
                return Json(false);
        }
        #region NEw
        
        public IActionResult New()
        {
            ViewData["DeptList"] = DeptRepo.GetAll();
            //ViewData["DeptList"] =new SelectList(context.Departments.ToList(),"Id","Name");// List<selectedList 
            return View("New");
        }
        //any action can handel get | post
        [HttpPost]//attribute handel only post (internal request)
        [ValidateAntiForgeryToken]//request.form["__Request"]
        public IActionResult SaveNEw(Employee EmpFromReq)
        {
            //if (EmpFromReq.Name != null)
            if(ModelState.IsValid==true)//validation Server Side
            {
                try
                {
                    EmpRepo.Add(EmpFromReq);
                    EmpRepo.Save();
                    return RedirectToAction("Index", "Employee");//,new { id=1,name="sadd"});
                }catch(Exception ex)
                {
                    //ModelState.AddModelError("DepartmentId", "Please Select DEpartment");
                    ModelState.AddModelError("Key1", ex.InnerException.Message);
                }
            }
            ViewData["DeptList"] = DeptRepo.GetAll();
            return View("New", EmpFromReq);
        }
        #endregion

        #region DEtails
        //get instructor details
        public IActionResult Details(int id,string name)
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
            Employee empMode = EmpRepo.GetById(id); 

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
            Employee? empMode = EmpRepo.GetAll("Dept").FirstOrDefault();
                
                //context.Employees.Include(e=>e.Dept)
               //.FirstOrDefault(e => e.Id == id);
            
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
           
            return View("DetailsVM", EmpVm);
        }
        #endregion
        
        #region EditRegion
        //Employee/Edit/1
        //Employee/Edit?id=1
        public IActionResult Edit(int id) {
            Employee empModel =EmpRepo.GetById(id);
            //viewModel
            //declare
            EmpWithDeptListViewModel empVm= new EmpWithDeptListViewModel();
            //map
            empVm.Id = empModel.Id;
            empVm.Name = empModel.Name;
            empVm.Salary = empModel.Salary;
            empVm.ImageUrl = empModel.ImageUrl;
            empVm.DepartmentId = empModel.DepartmentId;
            empVm.Email = empModel.Email;
            empVm.Departments = DeptRepo.GetAll();////////////
            //send
            
            return View("Edit", empVm);
            //view  "Edit"
            //Model EmpWithDeptListViewModel
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult SaveEdit(EmpWithDeptListViewModel EmpFromReq)
        {

            if(EmpFromReq.Name!=null && EmpFromReq.Salary > 6000)
            {
                //Update in Database using Entity Framwork
                //old refernce from db base pk (ID)
                Employee? Emp = new Employee();//Changed

                //change value
                Emp.Id = EmpFromReq.Id;
                Emp.Name = EmpFromReq.Name;
                Emp.Salary = EmpFromReq.Salary;
                Emp.ImageUrl = EmpFromReq.ImageUrl;
                Emp.Email = EmpFromReq.Email;
                Emp.DepartmentId = EmpFromReq.DepartmentId;
                
                EmpRepo.Update(Emp);
                EmpRepo.Save();
                return RedirectToAction("Index");
            }
            //refill list
            EmpFromReq.Departments = DeptRepo.GetAll();//
            return View("Edit",EmpFromReq);
        }
        #endregion
    }
}
