using MVCTasks.Models;

namespace MVCTasks.Repository
{
    public interface IEmployeeRepo
    {
        void Add(Employee newEmployee);
        List<Employee> GetAll();
        Employee GetByID(int id);
        void Update(Employee newEmployee);
        void Delete(int id);
        Employee UniqueEmail(string email);
    }
}
