using GISWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GISWebApp.Controllers
{
    public class BindController : Controller
    {
        //Test Primitive
        //Bind/TestPrmitive?name=Ahemd&age=12&id=11&color[1]=red&color[0]=blue
        //Bind/TestPrmitive/11?name=Ahemd&age=12
        /// <summary>
        /// <form action="/Bind/TestPrmitive" method="get">
        /// <input name="name"/>
        /// <input name="age"/>
        /// </form>
        /// </summary>
       
        public IActionResult TestPrmitive
            (string name ,int age,int id,string[] color)
        {
            return Content($"name={name}\tage={age}");
        }

        //Test Collection
        //Bind/TestDic?name=Christen&phone[Ahmed]=123&phone[mohmane]=456
        public IActionResult TestDic(Dictionary<string,string> phone,string name)
        {
            return Content("----------");
        }

        //Test Complex Type (Custom Type)
        //Bind/TestObj?Id=1&name=SD&ManagerName=Ahmed&eMps[0].Name=Mostafa
        //public IActionResult  TestObj(int Id, string Name, string ManagerName, List<Employee> Emps)
        public IActionResult  TestObj(Department dept)
        {
            return Content("");
        }
    }
}
