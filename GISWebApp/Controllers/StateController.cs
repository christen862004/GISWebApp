using Microsoft.AspNetCore.Mvc;

namespace GISWebApp.Controllers
{
    public class StateController : Controller
    {
        int Counter = 0;//stateManagement http statesless protocol
        //Server Session Per User
        //Cookie Per User "Browser"
        public IActionResult SetSession(string name)
        {
            //logic ....
            //info StateManagement write session
            HttpContext.Session.SetString("FirstName", name);
            HttpContext.Session.SetInt32("Age", 22);

            return Content("Session Save Success");
        }

        public IActionResult GetSession() {
            string n = HttpContext.Session.GetString("FirstName");
            int? a = HttpContext.Session.GetInt32("Age");//numer |null
            return Content($"name= {n}\t Age= {a}");
        }
        //use Cookie
        public IActionResult SetCookie(string name)
        {
            //Session Cookie "Expired with session Expired"
            HttpContext.Response.Cookies.Append("Name", name);
            
            //Presistent Cookie "Expiration duration" 
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            
            HttpContext.Response.Cookies.Append("Age", "22",cookieOptions);
            HttpContext.Response.Cookies.Append("Salary", "22000",cookieOptions);
            return Content("Cookie Saved");
        }
        //read from any action at any controller
        public IActionResult GetCookie()
        {
            string name=HttpContext.Request.Cookies["Name"];
            string age=HttpContext.Request.Cookies["Age"];

            return Content($"Name={name} \t Age={age}");
        }

    }
}
