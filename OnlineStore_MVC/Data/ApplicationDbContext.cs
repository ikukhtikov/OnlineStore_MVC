using Microsoft.EntityFrameworkCore;
using OnlineStore_MVC.Models;

namespace OnlineStore_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }
    }
}
