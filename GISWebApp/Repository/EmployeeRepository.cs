using GISWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GISWebApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //CRUD : Create - Read - Update - Delete
        CompanyContext context;

        public EmployeeRepository(CompanyContext ctx)
        {
            context = ctx;
        }

        public void Add(Employee obj)
        {
            //context.Add(obj);
            context.Employees.Add(obj);
        }

        public void Delete(int id)
        {
            //context.Remove()
            context.Employees.Remove(GetById(id));
        }

        public List<Employee> GetAll(string includes="")
        {
            if (includes == "")
                return context.Employees.ToList();
            else
                return context.Employees.Include(includes).ToList();
        }

        public List<Employee> GetByDept(int deptid)
        {
            return context.Employees.Where(e=>e.DepartmentId == deptid).ToList();   
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee obj)
        {
            Employee orgEmp=GetById(obj.Id);
            orgEmp.Name=obj.Name;
            orgEmp.Salary=obj.Salary;
            orgEmp.ImageUrl=obj.ImageUrl;
            orgEmp.Email=obj.Email;
            orgEmp.DepartmentId=obj.DepartmentId;
            //context.Update(orgEmp);
        }
    }
}
