using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore_MVC.Data;
using OnlineStore_MVC.Models;

namespace OnlineStore_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Метод отображения категорий
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() 
        {
            IEnumerable<Product> objList = _db.Product;

            foreach(var obj in objList)
            {
                obj.Category = _db.Category.FirstOrDefault(u => u.CategoryId == obj.CategoryId);
            };

            return View(objList);
        }

        // Метод GET - UPSERT
        public IActionResult Upsert(int? id) 
        {
            IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i => new SelectListItem
            {
                Text=i.CategoryName,
                Value = i.CategoryId.ToString()
            });

            ViewBag.CategoryDropDown = CategoryDropDown;
            
            Product product = new Product();
            if (id == null)
            {
                // this is for create
                return View(product);
            }
            else
            {
                product = _db.Product.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            return View();
        }

        // Метод POST для операции UPSERT (добавление в БД)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(obj);
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
