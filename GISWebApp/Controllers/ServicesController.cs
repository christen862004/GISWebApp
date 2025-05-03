using GISWebApp.Filtters;
using GISWebApp.Models;
using GISWebApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;


namespace GISWebApp.Controllers
{
    //[HandelError]
    //[Authorize]//16 action : 15 authorze - 1 allow guset
    public class ServicesController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public ServicesController(IDepartmentRepository DeptRepo)//injection at coustroctor
        {
            deptRepo = DeptRepo;
        }

        
        public IActionResult ShowMsg()
        {
            //how know this user is authanticted

            if (User.Identity.IsAuthenticated==true) {
                // Claim NameClaim= User.Claims.FirstOrDefault(c => c.Type == "ID");

                // return Content($"Welcome  {NameClaim.Value}");
                return Content($"Welcome {User.Identity.Name}");
            }
            return Content("Welcome Gust");
        }
        
        
        
        
        
        
        
        
        
        //[HandelError]
        
        public IActionResult MEthod1()
        {
            
            throw new Exception("Some Exceptoion HAppen :)");
        }
        //[HandelError]
        public IActionResult MEthod2()
        {
            throw new Exception("Some Exceptoion HAppen :)");
        }

        [AllowAnonymous]//default attribute all actions
        public IActionResult Index()//Employee emp,[FromServices]IDepartmentRepository DeptRepo)//injection at MEthod
        {
            ViewBag.Id = deptRepo.Id;
            return View();
            
        }
    }
}
