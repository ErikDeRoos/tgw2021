using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Order
{
    public class CartItem
    {
        [Key]
        public string ProductSlug { get; set; }
        
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string QuantityDescriptor { get; set; }

        public int Amount { get; set; }

        public decimal PricePerItem { get; set; }
    }
}
