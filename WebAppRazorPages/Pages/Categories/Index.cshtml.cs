using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;

namespace WebAppRazorPages.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        
        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(string sort)
        {
            IQueryable<Category> query = _db.Categories;
            
            if(sort == "display-order")
            {
                query = query.OrderBy(c => c.DisplayOrder);
            }

            Categories = query.ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var cat = await _db.Categories.FirstOrDefaultAsync(c=> c.Id == id);
            
            if(cat != null)
            {
                _db.Categories.Remove(cat);
                _db.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
