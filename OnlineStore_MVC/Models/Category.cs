using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore_MVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
