using Microsoft.AspNetCore.Mvc;
using MVCTasks.Models;
using MVCTasks.Repository;

namespace MVCTasks.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDBContext context;
        IEmployeeRepo EmpRepo;
        IDeparmentRepo DeptRepo;


        public EmployeeController(CompanyDBContext db, IEmployeeRepo employeeRepo, IDeparmentRepo deparmentRepo)
        {
            this.context = db;
            this.EmpRepo = employeeRepo;
            this.DeptRepo = deparmentRepo;
        }
        public IActionResult Add(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmpRepo.Add(emp);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("showAdd");
        }
        public IActionResult Index()
        {
            return View(EmpRepo.GetAll());
        }
        public IActionResult Read(int id)
        {
            Employee employee = EmpRepo.GetByID(id);
            return View(employee);
        }
        public IActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmpRepo.Update(emp);
                return RedirectToAction("Index");
            }
            return RedirectToAction("showUpdate");
        }
        public IActionResult Delete(int id)
        {
            EmpRepo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult showAdd()
        {
            ViewData["depts"] = DeptRepo.GetAll();
            return View();
        }
        public IActionResult showUpdate(int id)
        {
            ViewData["depts"] = DeptRepo.GetAll();
            return View(EmpRepo.GetByID(id));
        }
        public IActionResult CheckUniqueEmail(string email)
        {
            var emp = EmpRepo.UniqueEmail(email);
            if (emp != null)
                return Json(false);
            return Json(true);

        }
    }
}
