using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.DataModels;

namespace WebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext, ICustomerDataDomain, IOrderDataDomain, IProductDataDomain
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
