using GISWebApp.Models;
using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GISWebApp.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        //Employee (encrypt hidden
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string? ImageUrl { get; set; }

        [Display(Name="Personal Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        //FK
        public int DepartmentId { get; set; }
        //List<department>
        public List<Department> Departments { get; set; }
    }
}
