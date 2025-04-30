using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GISWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required] //No null overrride error message
        [MaxLength(25,ErrorMessage ="Name Mus be less thna 25 charecter")]
        [MinLength(3,ErrorMessage ="Name Must be More Than 2 charecter")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Salary Required")]//not null
        [Range(7000,50000,ErrorMessage ="Salary must between 7000 and 50000")]
        //[GreaterThan(ComparazonValue = 6000)]
        //[Remote("CheckSalary","Employee",ErrorMessage ="Invalid Salary",AdditionalFields = "DepartmentId")]
        public int Salary { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be png or jpg")]
        [Display(Name="Personal Image")]
        public string? ImageUrl { get; set; }

        [Unique]
        public string? Email { get; set; }

        [ForeignKey("Dept")]
        //[Remote("CheckSalary","Employee",ErrorMessage ="Invalid Salary",AdditionalFields = "Salary")]
        public int DepartmentId { get; set; } = 2;
        
        
        public Department? Dept { get; set; } 
    }
}
