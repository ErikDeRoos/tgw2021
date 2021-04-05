using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ShoppingChartViewModel
    {
        public List<ShoppingChartItemViewModel> Items { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class ShoppingChartItemViewModel
    {
        public string ProductName { get; set; }
        public string ProductImageLink { get; set; }
        public string ProductQuantityType { get; set; }
        public int Amount { get; set; }
        public int IndividualValue { get; set; }
    }
}
