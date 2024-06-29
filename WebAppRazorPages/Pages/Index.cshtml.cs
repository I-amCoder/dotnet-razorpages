using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;

namespace WebAppRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _db;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IEnumerable<Product> Products { get; set; }

        public void OnGet()
        {
            
            Products = _db.Products;
        }
    }
}
