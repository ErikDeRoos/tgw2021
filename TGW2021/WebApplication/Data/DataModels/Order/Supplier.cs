using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Order
{
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNr { get; set; }

        public ICollection<ProductSupplier> SuppliesProducts { get; set; }
    }
}
