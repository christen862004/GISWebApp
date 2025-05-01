using GISWebApp.Models;

namespace GISWebApp.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        //extra employee MEthod 
        List<Employee> GetByDept(int deptid);
    }
}
