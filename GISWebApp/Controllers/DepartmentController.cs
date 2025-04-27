using GISWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GISWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext context = new CompanyContext();
        //<a request Get
        [HttpGet]
        public IActionResult Index()
        {
            List<Department> departmentList = context.Departments.ToList();
            return View("Index",departmentList);//View "Index"
        }

        #region New
        public IActionResult New()
        {
            return View("New");//Model = null
        }
        ///Department/SaveNew?Name=dept1&ManagerName=Ahmed <summary>
        //can server request type (Get |Post)
        [HttpPost]
        public IActionResult SaveNew(Department deptFromReq)//string Name,string ManagerName)
        {
            //if (Request.Method == "POST")
            //{
            //}
            //return BadRequest();
            //Validation server
            if (deptFromReq.Name != null && deptFromReq.ManagerName != null)
            {
                context.Departments.Add(deptFromReq);
                context.SaveChanges();//thow exception or run normal

                return RedirectToAction("Index", "Department");//call action
            }
            //ViewData["Error"]="Must";
            return View("New", deptFromReq);//wrong data
            
        }

        #endregion
    }
}
