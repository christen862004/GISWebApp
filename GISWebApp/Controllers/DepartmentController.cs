using GISWebApp.Models;
using GISWebApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GISWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        //CompanyContext context = new CompanyContext();
        //poly
        IDepartmentRepository DeptRepo;
        public DepartmentController(IDepartmentRepository deptRepo)
        {
            DeptRepo = deptRepo;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]//check
        public IActionResult Index()
        {
            List<Department> departmentList = DeptRepo.GetAll();
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
                DeptRepo.Add(deptFromReq);
                DeptRepo.Save();

                return RedirectToAction("Index", "Department");//call action
            }
            //ViewData["Error"]="Must";
            return View("New", deptFromReq);//wrong data
            
        }

        #endregion
    }
}
