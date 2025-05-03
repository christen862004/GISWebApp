using GISWebApp.Models;

namespace GISWebApp.Repository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        //empty no more method
        string Id { get; set; }//unique identifier 
    }
}
