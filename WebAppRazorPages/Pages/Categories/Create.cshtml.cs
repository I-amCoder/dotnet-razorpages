using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;

namespace WebAppRazorPages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;
        
        [BindProperty]
        public Category Category { get; set;  } 

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            await _db.categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
