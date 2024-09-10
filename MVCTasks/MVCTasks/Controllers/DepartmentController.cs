using Microsoft.AspNetCore.Mvc;
using MVCTasks.Models;
using MVCTasks.Repository;

namespace MVCTasks.Controllers
{
    public class DepartmentController : Controller
    {
        IDeparmentRepo DeptRepo;
        public DepartmentController(IDeparmentRepo deparmentRepo)
        {
            this.DeptRepo = deparmentRepo;
        }
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                DeptRepo.Add(department);
                return RedirectToAction("Index");
            }
            return RedirectToAction("showAdd");
        }
        public IActionResult Index()
        {
            return View(DeptRepo.GetAll());
        }
        public IActionResult Read(int id)
        {
            Department department = DeptRepo.GetByID(id);
            return Content($"{department.ID}\t{department.DeptName}\t{department.Capacity}");
        }
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                DeptRepo.Update(department);
                return RedirectToAction("Index");
            }
            return RedirectToAction("showUpdate");
        }
        public IActionResult Delete(int id)
        {
            DeptRepo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult showAdd()
        {
            return View();
        }
        public IActionResult showUpdate()
        {
            return View();
        }
    }
}
