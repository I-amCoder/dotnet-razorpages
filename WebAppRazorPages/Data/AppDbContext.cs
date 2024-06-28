using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Models;
using System;
using System.Text;

namespace WebAppRazorPages.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly string _adminId;
        private readonly string _adminRoleId;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
            _adminId = Guid.NewGuid().ToString();   
            _adminRoleId = Guid.NewGuid().ToString();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedRoles(builder);
            SeedUsers(builder);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            
                
        }

        private void SeedRoles(ModelBuilder builder)
        {
            var admin = new IdentityRole { Id = _adminRoleId ,Name = "admin", NormalizedName = "Admin" };
            var seller = new IdentityRole { Name = "seller", NormalizedName = "Seller" };
            var customer = new IdentityRole { Name = "customer", NormalizedName = "Customer" };

            builder.Entity<IdentityRole>().HasData(admin, seller, customer);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            string adminId = _adminId;
            string adminEmail = "admin@admin.com";
            string adminUsername = "admin@admin.com";

            ApplicationUser user = new()
            {
                Id = adminId,
                FirstName = "Junaid",
                LastName = "Ali",
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                CreatedDate = DateTime.Now,
                UserName = adminUsername,
                NormalizedUserName = adminUsername.ToUpper(),
                PasswordHash = GetStringHash("secret")
            };

            builder.Entity<ApplicationUser>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = _adminRoleId,
                UserId = _adminId
            });


        }


        public string GetStringHash(string str)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            return hasher.HashPassword(null, str);
        }
    }
}
