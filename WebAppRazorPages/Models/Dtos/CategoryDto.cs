using System.ComponentModel.DataAnnotations;

namespace WebAppRazorPages.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
    }
}
