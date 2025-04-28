using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GISWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Salary { get; set; }

        [Display(Name="Personal Image")]
        public string? ImageUrl { get; set; }
        public string? Email { get; set; }

        [ForeignKey("Dept")]
        public int DepartmentId { get; set; } = 2;

        public Department Dept { get; set; } 
    }
}
