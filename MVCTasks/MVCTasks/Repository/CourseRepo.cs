using MVCTasks.Models;

namespace MVCTasks.Repository
{
    public class CourseRepo : ICourseRepo
    {
        CompanyDBContext context;
        public CourseRepo(CompanyDBContext db)
        {
            context = db;
        }
        public CourseRepo()
        {
            
        }
        public void Add(Course newCourse)
        {
            newCourse.Status = true;
            context.Courses.Add(newCourse);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Courses.FirstOrDefault(c => c.ID == id).Status = false;
            context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return context.Courses.Where(c => c.Status == true).ToList();
        }

        public Course GetByID(int id)
        {
            return context.Courses.FirstOrDefault(c => c.ID == id && c.Status == true);
        }

        public void Update(Course newCourse)
        {
            newCourse.Status = true;
            context.Courses.Update(newCourse);
            context.SaveChanges();
        }
    }
}
