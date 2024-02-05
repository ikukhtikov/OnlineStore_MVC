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

        // Метод POST для операции CREATE (добавление в БД)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Метод GET для операции EDIT (редактирование категории)
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Метод POST для операции EDIT (обнавление строки в БД)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Метод GET для операции DELETE (удаление категории)
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // Метод POST для операции DELETE (удаление строки в БД)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
