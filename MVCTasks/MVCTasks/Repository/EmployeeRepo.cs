using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVCTasks.Models;

namespace MVCTasks.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        CompanyDBContext context = new CompanyDBContext();
        public void Add(Employee newEmployee)
        {
            context.Employees.Add(new Employee
            {
                Name = newEmployee.Name,
                Salary = newEmployee.Salary,
                DeptID = newEmployee.DeptID,
                Email = newEmployee.Email,
                Status = true
            });
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Employees.FirstOrDefault(e => e.ID == id).Status = false;
            context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return context.Employees.Where(e=>e.Status == true).ToList();
        }

        public Employee GetByID(int id)
        {
            return context.Employees.FirstOrDefault(e => e.ID == id && e.Status == true);
        }

        public Employee UniqueEmail(string email)
        {
            return context.Employees.FirstOrDefault(e => e.Email == email);
        }

        public void Update(Employee newEmployee)
        {
            Employee oldEmp = context.Employees.FirstOrDefault(e => e.ID == newEmployee.ID);
            oldEmp.Name = newEmployee.Name;
            oldEmp.Salary = newEmployee.Salary;
            oldEmp.DeptID = newEmployee.DeptID;
            context.SaveChanges();
        }
    }
}
