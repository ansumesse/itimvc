using Microsoft.AspNetCore.Mvc;
using MVCTasks.Models;

namespace MVCTasks.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDBContext context = new CompanyDBContext();
        public string Add(string name, decimal salary, int deptID)
        {
            context.Employees.Add(new Employee
            {
                Name = name,
                Salary = salary,
                DeptID = deptID
            });
            context.SaveChanges();
            return "ADDED";
        }
        public JsonResult Index()
        {
            return Json(context.Employees.ToList());
        }
        public string Read(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.ID == id);
            return $"{employee.ID}\t{employee.Name}\t{employee.Salary}\t{employee.DeptID}";
        }
        public string Update(int id, string name, decimal salary, int deptID)
        {
            Employee oldEmp = context.Employees.FirstOrDefault(e => e.ID == id);
            oldEmp.Name = name;
            oldEmp.Salary = salary;
            oldEmp.DeptID = deptID;
            context.SaveChanges();
            return "Updated";
        }
        public string Delete(int id)
        {
            context.Employees.Remove(context.Employees.FirstOrDefault(e => e.ID == id));
            return "Deleted";
        }
    }
}
