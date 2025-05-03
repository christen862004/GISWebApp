using Microsoft.CodeAnalysis.CodeActions;

namespace GISWebApp.Models
{
    public class UserAccount
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

      //  public Employee Employee { get; set; }
    }
}
