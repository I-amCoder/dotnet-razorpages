using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAppRazorPages.Models.Dtos
{
    public class ProductUpdate
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;


        [MaxLength(100)]
        public string Brand { get; set; } = string.Empty;

        [Required]
        [Precision(16)]
        public decimal Price { get; set; }

        public IFormFile? Image { get; set; } 

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
