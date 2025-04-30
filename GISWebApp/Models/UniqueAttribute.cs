using GISWebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace GISWebApp.Models
{
    //Server Side Only 
    public class UniqueAttribute:ValidationAttribute
    {
        //Take property value to validation and whole Emploee object
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string email = value.ToString();
            
            //int age = int.Parse(value.ToString());
            
            Employee EmpFromRequest = validationContext.ObjectInstance as Employee;
            //Employee EmpFromRequest =(Employee) validationContext.ObjectInstance;

            CompanyContext context = new CompanyContext();
            Employee empFromDb= context.Employees
                .FirstOrDefault(e => e.Email == email && e.DepartmentId == EmpFromRequest.DepartmentId);
            
            //Per Depted
            if(empFromDb == null) {
                //email unique
                return ValidationResult.Success;//valid value
            }
            return new ValidationResult("Email already exists at the same deptament :(");
            
        }
    }
}
