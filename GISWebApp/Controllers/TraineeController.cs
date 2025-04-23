using GISWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GISWebApp.Controllers
{
    public class TraineeController : Controller
    {
        TraineeBL traineeBL = new TraineeBL();

        //Trainee/All
        public IActionResult All()
        {
            //ask model get trainee data
            List<Trainee> tList= traineeBL.GetAll();
            //send view
            return View("ShowAll",tList);
            //go to view with name  "ShowAll"
            //Model List<trainee> comming from Model
        }

        //Trainee/Details/1
        //Trainee/Details?id=100
        public IActionResult Details(int id)
        {
            Trainee TraineeModel= traineeBL.GetByID(id);
            if (TraineeModel == null)
            {
                return NotFound();
            }
            return View("Details", TraineeModel);
            //View name = "DEtails"
            //Model Type Trainee
        }
    }
}
