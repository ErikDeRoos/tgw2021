using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Order
{
    public class ProductComposition
    {
        [Key]
        public Guid ProductId { get; set; }

        public ICollection<ProductStock> ComponentsStock { get; set; }
        
        public bool Deactivated { get; set; }
    }
}
