using EfCore.Domain.ProductAgg;
using EfCore.Domain.ProductCategoryAgg;
using EfCore.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;


namespace EfCore.Infrastructure.EfCore;

public class EfContext: DbContext
{
    public DbSet<Product?> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    public EfContext(DbContextOptions<EfContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMapping());
        modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
        base.OnModelCreating(modelBuilder);
        
    }
}