using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Models;

namespace WebAppRazorPages.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Category> categories {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "Admin";

            var seller = new IdentityRole("seller");
            seller.NormalizedName = "Seller";

            var customer = new IdentityRole("customer");
            customer.NormalizedName = "Customer";

            builder.Entity<IdentityRole>().HasData(admin, seller, customer);
        }
    }
}
