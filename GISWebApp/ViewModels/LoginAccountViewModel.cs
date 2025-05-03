using System.ComponentModel.DataAnnotations;

namespace GISWebApp.ViewModels
{
    public class LoginAccountViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
