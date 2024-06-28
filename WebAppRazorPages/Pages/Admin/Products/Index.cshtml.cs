using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;

namespace WebAppRazorPages.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _environment;

        public IEnumerable<Product> Products { get; set; }

        public IndexModel(AppDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }   

        public async Task OnGet()
        {
            Products = await _db.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    var imagePath  = Path.Combine(_environment.WebRootPath ,product.ImagePath.TrimStart('/'));
                    if(System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
