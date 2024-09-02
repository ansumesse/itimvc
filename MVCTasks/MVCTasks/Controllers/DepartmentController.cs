using Microsoft.AspNetCore.Mvc;
using MVCTasks.Models;

namespace MVCTasks.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyDBContext context = new CompanyDBContext();
        public string Add(int id, string deptname,  int capacity)
        {
            context.Departments.Add(new Department
            {
                ID = id,
                DeptName = deptname,
                Capacity = capacity
            });
            context.SaveChanges();
            return "ADDED";
        }
        public JsonResult Index()
        {
            return Json(context.Departments.ToList());
        }
        public string Read(int id)
        {
            Department department = context.Departments.FirstOrDefault(d => d.ID == id);
            return $"{department.ID}\t{department.DeptName}\t{department.Capacity}";
        }
        public string Update(int id, string deptname, int capacity)
        {
            Department oldDept = context.Departments.FirstOrDefault(e => e.ID == id);
            oldDept.ID = id;
            oldDept.DeptName = deptname;
            oldDept.Capacity = capacity;
            context.SaveChanges();
            return "Updated";
        }
        public string Delete(int id)
        {
            context.Departments.Remove(context.Departments.FirstOrDefault(e => e.ID == id));
            return "Deleted";
        }
    }
}
