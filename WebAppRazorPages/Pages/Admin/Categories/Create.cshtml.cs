using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;
using WebAppRazorPages.Models.Dtos;

namespace WebAppRazorPages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public CreateModel(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        private readonly AppDbContext _db;
        
        [BindProperty]
        public CategoryDto Input { get; set;  } 

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            if (Input.Name == Input.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display orde cannot match the name");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var Category = _mapper.Map<Category>(Input);

            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
