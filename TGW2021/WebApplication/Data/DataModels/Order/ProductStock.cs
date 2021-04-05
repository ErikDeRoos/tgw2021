using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Order
{
    public class ProductStock
    {
        [Key]
        public Guid Id { get; set; }
        public ICollection<ProductSupplier> Suppliers { get; set; }
        public Supplier PreferredSupplier { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }
        public int AvailableOnLocation { get; set; }
        public bool AvailableAtSupplier { get; set; }
        public bool EndOfLife { get; set; }
    }
}
