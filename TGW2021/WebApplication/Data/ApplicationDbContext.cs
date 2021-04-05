using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Data.DataModels;
using WebApplication.Data.DataModels.Customer;
using WebApplication.Data.DataModels.Order;
using WebApplication.Data.DataModels.Product;

namespace WebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext, ICustomerDataDomain, IOrderDataDomain, IProductDataDomain
    {
        #region Customer bounded context
        public DbSet<Customer> Customers { get; set; }
        #endregion

        #region Order bounded context
        public DbSet<Cart> Carts { get; set; }

        public DbSet<ProductComposition> ProductCompositions { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        #endregion

        #region Product bounded context
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategoryProjection> ProductCategoryProjections { get; set; }
        #endregion




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Define the model.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSupplier>()
                .HasKey(ps => new { ps.ProductStockId, ps.SupplierId });
            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.ProductStock)
                .WithMany(ps => ps.Suppliers)
                .HasForeignKey(ps => ps.ProductStockId);
            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Supplier)
                .WithMany(s => s.SuppliesProducts)
                .HasForeignKey(ps => ps.SupplierId);

            base.OnModelCreating(modelBuilder);
        }




        public async Task<List<ProductCategoryProjection>> GetActiveProductsProjection()
        {
            return await ProductCategoryProjections.Include(p => p.Products).ToListAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAndProducts()
        {
            return await Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task InsertNewActiveProductsProjection(List<ProductCategoryProjection> newData)
        {
            ProductCategoryProjections.RemoveRange(ProductCategoryProjections);
            ProductCategoryProjections.AddRange(newData);
            await SaveChangesAsync();
        }
    }
}
