using Microsoft.EntityFrameworkCore;
using order_management_service.Core.Entities;

namespace order_management_service.Data;

public class OrderManagementDbContext : DbContext
{
    public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Company)
            .HasForeignKey(p => p.CompanyId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Company)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CompanyId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Company)
            .WithMany()
            .HasForeignKey(o => o.CompanyId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany()
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
    }
}
