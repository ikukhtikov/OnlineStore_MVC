using Microsoft.AspNetCore.Mvc;
using OnlineStore_MVC.Data;
using OnlineStore_MVC.Models;

namespace OnlineStore_MVC.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Метод отображения категорий
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() 
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }

        // Метод GET для операции CREATE (создание категории)
        public IActionResult Create() 
        {
            return View();
        }

        // Метод POST для операции CREATE (добавление в БД)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
