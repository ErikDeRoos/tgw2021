using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Customer
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
    }
}
