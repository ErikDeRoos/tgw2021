using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Product
{
    public class ProductProjection
    {
        [Key]
        public string ProductId { get; set; }
        public string ProductDisplayName { get; set; }

        public string Description { get; set; }
        public int QuantityPerPackage { get; set; }
        public string QuantityDescriptor { get; set; }
        public decimal Price { get; set; }
        public bool HasStock { get; set; }
    }
}
