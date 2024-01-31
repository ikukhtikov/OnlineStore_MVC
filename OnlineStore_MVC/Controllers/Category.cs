using System.ComponentModel.DataAnnotations;

namespace OnlineStore_MVC.Controllers
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int DisplayOrder { get; set; }

    }
}
