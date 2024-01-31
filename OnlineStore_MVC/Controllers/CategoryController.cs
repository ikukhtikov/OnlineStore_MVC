using Microsoft.AspNetCore.Mvc;
using OnlineStore_MVC.Data;
using OnlineStore_MVC.Models;

namespace OnlineStore_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Метод отображения категорий
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() 
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        // Метод GET для операции CREATE (создание категории)
        public IActionResult Create() 
        {
            return View();
        }
    }
}
