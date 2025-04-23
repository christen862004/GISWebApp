
using GISWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace GISWebApp.Controllers
{
    //Classs catch request : End Controller  & inherit from Controller Class
    public class HomeController : Controller
    {
        //MEthod call Actions
        //1) Must Be Public 
        //2) Cant Be to Static
        //3) Cant Be OverLoad only in one case this aviable

        //Home/ShowText
        public ContentResult ShowText()
        {
          
            //logic ....

            //Declare
            ContentResult result = new ContentResult();
            //set data
            result.Content = "' Hi From My First Mvc MEthod";
            //return
            return result;//response string html
        }
        //Home/ShowView
        
        public ViewResult ShowView()
        {
            
            //logic calling model method
            return View("View1");
        }
        //Home/showMix ? no =sadjhasj & name=ahmed & id=1  ==>string
        //Home/showMix/1 ? no =2 & name=Mohamed ==>view
        //DIP
        public IActionResult ShowMix(int no,string name,int id)//endpoint view or content
        {
            if (no % 2 == 0)
            {
                //logic model
                return View("View1");//calling
            }
            else
            {
                return Content("Hi from Action");
            }
            
        }
        //Dry
        //public ViewResult View(string name)
        //{
        //    ViewResult result = new ViewResult();//declaration define object
        //    result.ViewName = name; ; //set info
        //    return result;
        //}











        /// Action can return [response type]  :ActionREsult
        /// 1) content   ==> ContentResult   ==> Content("Mesg")
        /// 2) View      ==> ViewResult      ==> View(ViewNAme)
        /// 3) json      ==> JsonResult      ==> Json(obj)
        /// 4) notfound  ==> NotFoundREsult  ==> NotFount()
        /// 5) file      
        /// 6) void      ==> EmptyResult
        /// .....





        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
