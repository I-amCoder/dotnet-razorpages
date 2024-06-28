using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;

namespace WebAppRazorPages.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext _db;

        public DashboardModel(AppDbContext db)
        {
            _db = db;
        }

        public int CategoriesCount { get; set; }
        public int ProductsCount { get; set; }

        public void OnGet()
        {
            CategoriesCount = _db.Categories.Count();
            ProductsCount = _db.Products.Count();
        }
    }
}
