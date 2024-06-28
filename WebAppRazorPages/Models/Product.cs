using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppRazorPages.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required] 
        public string Description { get; set; } = string.Empty;


        [MaxLength(100)]
        public string Barnd { get; set; } = string.Empty;
        
        [Required]
        [Precision(16)]
        public decimal Price { get; set; } 
        
        [Required] 
        public string ImagePath { get; set; } = string.Empty ;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; } 

        public DateTime CreatedAt { get; set; }
    }
}
