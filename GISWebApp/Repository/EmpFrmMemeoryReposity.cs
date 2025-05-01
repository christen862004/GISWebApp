using GISWebApp.Models;

namespace GISWebApp.Repository
{
    public class EmpFrmMemeoryReposity : IEmployeeRepository
    {
        List<Employee> employees;
        public EmpFrmMemeoryReposity()
        {
            employees = new() {
                new Employee(){Id=1,Name="Ahmed"},
                new Employee(){Id=2,Name="Toqa"},
                new Employee(){Id=3,Name="Marwan"},
                new Employee(){Id=4,Name="Hassan"},
            };
        }
        public void Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(string includes = "")
        {
            return employees;
        }

        public List<Employee> GetByDept(int deptid)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
