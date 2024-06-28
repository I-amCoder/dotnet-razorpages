using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;

namespace WebAppRazorPages.Pages.Categories
{
    public class EditModel : PageModel
    {
        public EditModel(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;

        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display orde cannot match the name");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }




            _db.Categories.Update(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
