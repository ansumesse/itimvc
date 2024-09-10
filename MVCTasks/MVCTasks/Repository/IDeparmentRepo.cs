using MVCTasks.Models;

namespace MVCTasks.Repository
{
    public interface IDeparmentRepo
    {
        void Add(Department newDepartment);
        List<Department> GetAll();
        Department GetByID(int id);
        void Update(Department newDepartment);
        void Delete(int id);
    }
}
