using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;

namespace WebAppRazorPages.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IEnumerable<Product> Products { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }   

        public void OnGet()
        {
            Products = _db.Products;
        }
    }
}
