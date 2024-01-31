using Microsoft.AspNetCore.Mvc;

namespace OnlineStore_MVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
