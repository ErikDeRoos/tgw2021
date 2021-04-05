using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Product
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Slug cannot exceed 30 characters.")]
        public string Slug { get; set; }

        [StringLength(30, ErrorMessage = "DisplayName cannot exceed 30 characters.")]
        public string DisplayName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
