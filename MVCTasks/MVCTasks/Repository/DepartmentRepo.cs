using MVCTasks.Models;

namespace MVCTasks.Repository
{
    public class DepartmentRepo : IDeparmentRepo
    {
        CompanyDBContext context = new CompanyDBContext();
        public void Add(Department newDepartment)
        {
            context.Departments.Add(new Department
            {
                ID = newDepartment.ID,
                DeptName = newDepartment.DeptName,
                Capacity = newDepartment.Capacity,
                Status = true
            });
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Departments.FirstOrDefault(d => d.ID == id).Status = false;
            context.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return context.Departments.Where(d => d.Status == true).ToList();
        }

        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(d => d.ID == id && d.Status == true);
        }

        public void Update(Department newDepartment)
        {
            Department oldDept = context.Departments.FirstOrDefault(e => e.ID == newDepartment.ID);
            oldDept.ID = newDepartment.ID;
            oldDept.DeptName = newDepartment.DeptName;
            oldDept.Capacity = newDepartment.Capacity;
            context.SaveChanges();
        }
    }
}
