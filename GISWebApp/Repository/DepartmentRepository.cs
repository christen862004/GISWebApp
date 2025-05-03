using GISWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GISWebApp.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        CompanyContext context;
        public string Id { get; set; }


        public DepartmentRepository(CompanyContext _Ctx)//inject
        {
            context = _Ctx; 
            Id =Guid.NewGuid().ToString();
        }


        //define function once, call alot to times
        public void Add(Department obj)
        {
            context.Departments.Add(obj);
        }

        public void Delete(int id)
        {
            context.Departments.Remove(GetById(id));
        }

        public List<Department> GetAll(string includes="")//GetAll() | GetAll("Emps")
        {
            List<Department> list;
            if (includes == "")
            {
                list = context.Departments.ToList();
            }
            else
            {
                list = context.Departments.Include(includes).ToList();
            }
            return list;
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            //get old ref
            Department deptfromDb = GetById(obj.Id);
            //change
            deptfromDb.Name= obj.Name;
            deptfromDb.ManagerName= obj.ManagerName;

            //context.Update(obj);

        }
    }
}
