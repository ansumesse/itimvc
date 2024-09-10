using Microsoft.AspNetCore.Mvc;
using MVCTasks.Models;
using MVCTasks.Repository;

namespace MVCTasks.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepo CourseRepo;
        public CourseController(ICourseRepo courseRepo)
        {
            this.CourseRepo = courseRepo;
        }
        public IActionResult Index()
        {
            return View(CourseRepo.GetAll());
        }
        public IActionResult ShowNew()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Course newCourse)
        {
            if (ModelState.IsValid)
            {
                CourseRepo.Add(newCourse);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("ShowNew");
        }
        public IActionResult ShowUpdate(int id)
        {
            return View(CourseRepo.GetByID(id));
        }
        [HttpPost]
        public IActionResult Update(Course newCourse)
        {
            newCourse.Status = true;
            if (ModelState.IsValid)
            {
                CourseRepo.Update(newCourse);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("ShowUpdate");
        }
        public IActionResult Delete(int id)
        {
            CourseRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
