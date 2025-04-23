using System.Security.Principal;

namespace GISWebApp.Models
{
    public class Trainee
    {
        public int Id { get; set; }//auto implement property
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    }
}
