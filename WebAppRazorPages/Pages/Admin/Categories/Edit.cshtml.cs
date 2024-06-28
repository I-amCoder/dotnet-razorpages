using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;
using WebAppRazorPages.Models.Dtos;

namespace WebAppRazorPages.Pages.Categories
{
    public class EditModel : PageModel
    {
        public EditModel(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        [BindProperty]
        public CategoryDto Input { get; set; }
        public void OnGet(int id)
        {
            var cat = _db.Categories.FirstOrDefault(c => c.Id == id);
            Input = _mapper.Map<CategoryDto>(cat);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Input.Name == Input.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Input.Name", "The Display orde cannot match the name");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }


            
            var Category = _mapper.Map<Category>(Input);

            _db.Categories.Update(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
