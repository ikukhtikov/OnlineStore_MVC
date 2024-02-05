using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore_MVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Порядок отображения категорий должен быть больше 0.")]
        public int DisplayOrder { get; set; }

    }
}
