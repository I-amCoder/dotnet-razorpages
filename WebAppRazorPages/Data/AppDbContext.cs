using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Models;

namespace WebAppRazorPages.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Category> categories {  get; set; }
    }
}
