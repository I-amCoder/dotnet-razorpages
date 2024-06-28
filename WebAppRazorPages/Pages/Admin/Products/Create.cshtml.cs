using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;
using WebAppRazorPages.Models.Dtos;
using AutoMapper;

namespace WebAppRazorPages.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(AppDbContext db, IMapper mapper, IWebHostEnvironment environment)
        {
            _db = db;
            _mapper = mapper;
            _environment = environment;
        }

        [BindProperty]
        public ProductCreate Input { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public void OnGet()
        {
            Categories = _db.Categories;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = _db.Categories;
                return Page();
            }

            Product product = _mapper.Map<Product>(Input);

            if (Input.Image != null && Input.Image.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(Input.Image.FileName).ToLower();
                var uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");
                
                if(!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                
                var filePath = Path.Combine(uploadFolder, imageName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.Image.CopyToAsync(stream);
                }

                product.ImagePath = "/uploads/" + imageName;
            }

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
