using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services.Generic;

namespace WebApplication.Services.Product.Models
{
    public class CustomerProductCatalogCategoryQuery : Query
    {
        public string CategoryId { get; set; }
    }
}
