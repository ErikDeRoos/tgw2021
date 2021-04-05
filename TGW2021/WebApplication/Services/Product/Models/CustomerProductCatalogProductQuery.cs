using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services.Generic;

namespace WebApplication.Services.Product.Models
{
    public class CustomerProductCatalogProductQuery : Query
    {
        public string CategoryId { get; set; }
        public string ProductId { get; set; }
    }
}
