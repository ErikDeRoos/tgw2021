using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data.DataModels.Order
{
    public class ProductSupplier
    {
        public Guid ProductStockId { get; set; }
        public Guid SupplierId { get; set; }

        [Required]
        public Supplier Supplier { get; set; }
        [Required]
        public ProductStock ProductStock { get; set; }
        [Required]
        public string SupplierCode { get; set; }
    }
}
