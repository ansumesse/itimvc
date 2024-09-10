using MVCTasks.Models;

namespace MVCTasks.Repository
{
    public interface ICourseRepo
    {
        void Add(Course newCourse);
        List<Course> GetAll();
        Course GetByID(int id);
        void Update(Course newCourse);
        void Delete(int id);
    }
}
