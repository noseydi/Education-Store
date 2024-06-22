using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        // public DbSet<Products> products => Set<Products>();
        //public DbSet<ProductType> productstype => Set<ProductType>();
        //public DbSet<ProductBrand> productbrand => Set<ProductBrand>();
        public DbSet<Products> products { get; set; }
        public DbSet<ProductType> productstype { get; set; }
        public DbSet<ProductBrand> productbrand { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
