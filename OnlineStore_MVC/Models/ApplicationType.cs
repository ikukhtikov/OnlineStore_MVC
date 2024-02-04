using System.ComponentModel.DataAnnotations;

namespace OnlineStore_MVC.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
