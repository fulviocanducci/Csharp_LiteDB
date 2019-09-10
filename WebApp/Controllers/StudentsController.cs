using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace WebApp.Controllers
{
    public class StudentsController : Controller
    {
        public RepositoryStudentsBase RepositoryStudents { get; }

        public StudentsController(RepositoryStudentsBase repositoryStudentsBase)
        {
            RepositoryStudents = repositoryStudentsBase;
        }
        
        public ActionResult Index()
        {
            return View(RepositoryStudents.All(x => x.Name, QueryOrder.Descending));
        }
        
        public ActionResult Details(int id)
        {
            return View(RepositoryStudents.Find(id));
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Students student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RepositoryStudents.Insert(student);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
                
        public ActionResult Edit(int id)
        {
            return View(RepositoryStudents.Find(id));
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Students student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RepositoryStudents.Update(student);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
                
        public ActionResult Delete(int id)
        {
            return View(RepositoryStudents.Find(id));
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                RepositoryStudents.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}