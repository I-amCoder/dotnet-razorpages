using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;
using WebAppRazorPages.Models.Dtos;

namespace WebAppRazorPages.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        public EditModel(AppDbContext db, IMapper mapper, IWebHostEnvironment environment)
        {
            _db = db;
            _mapper = mapper;
            _environment = environment;
        }

        [BindProperty]
        public IEnumerable<Category> Categories { get; set; }

        [BindProperty]
        public ProductUpdate Input { get; set; }

        public IActionResult OnGet(int id)
        {
            Categories = _db.Categories;
            var product = _db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return RedirectToPage("Index");
            }

            Input = _mapper.Map<ProductUpdate>(product);


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                Categories = _db.Categories;
                return Page();
            }

            var product = _db.Products.FirstOrDefault(p => p.Id == id);


            if (product == null)
            {
                return RedirectToPage("Index");
            }

            // Map Properties Manually
            product.Name = Input.Name;
            product.Price = Input.Price;
            product.Description = Input.Description;
            product.Brand = Input.Brand;
            product.CategoryId = Input.CategoryId;


            if (Input.Image != null && Input.Image.Length > 0)
            {
                // Delete Old Image File as Well
                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    var oldFilePath = Path.Combine(_environment.WebRootPath, product.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }


                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(Input.Image.FileName).ToLower();
                var uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadFolder))
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



            _db.Products.Update(product);
            await _db.SaveChangesAsync();



            return RedirectToPage("Index");
        }
    }
}