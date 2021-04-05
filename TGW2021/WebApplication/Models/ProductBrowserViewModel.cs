using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ProductBrowserViewModel
    {
        public List<ProductBrowserCategoryViewModel> ProductTree { get; set; }
    }

    public class ProductBrowserCategoryViewModel
    {
        public bool Opened { get; set; }
        public string ProductCategoryDisplayName { get; set; }
        public string ProductCategoryId { get; set; }
        public List<ProductBrowserItemViewModel> Products { get; set; }
    }

    public class ProductBrowserItemViewModel
    {
        public bool Selected { get; set; }
        public string ProductDisplayName { get; set; }
        public string ProductId { get; set; }
    }
}
