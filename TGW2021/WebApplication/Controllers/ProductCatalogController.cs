using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    public class ProductCatalogController : Controller
    {
        [Route("{category}")]
        public IActionResult Category(string category)
        {
            return View();
        }

        [Route("{category}/{productId}")]
        public IActionResult Product(string category, string productId)
        {
            return View();
        }
    }
}
