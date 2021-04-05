using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Product
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public Category Category { get; set; }  // 1-many for category-product for now. Simpler to edit then many-to-many
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Slug cannot exceed 10 characters.")]
        public string Slug { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "DisplayName cannot exceed 30 characters.")]
        public string DisplayName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        public int QuantityPerPackage { get; set; }
        public string QuantityDescriptor { get; set; }

        public decimal Price { get; set; }

        public bool Discontinued { get; set; }
    }
}
