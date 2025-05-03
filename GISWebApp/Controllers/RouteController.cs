using Microsoft.AspNetCore.Mvc;

namespace GISWebApp.Controllers
{
    public class RouteController : Controller
    {
        //Route/MEthod1?age=12 (defualt route)
        //r1?age=12            (Custom Route)
        //r1/12/mohmed   (3 segment)
        //r1/22          (2 segment)
        //[Route("r1/{age:int}/{name?}")]//the only route to call this action
        public IActionResult Method1(int age,string name)
        {
            return Content("Method1");
        }
        //Route/Method2
        //r2
        public IActionResult MEthod2()
        {
            return Content("Method2");
        }
    }
}
