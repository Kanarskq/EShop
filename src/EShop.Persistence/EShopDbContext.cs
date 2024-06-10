using EShop.Core.Domain.Carts.Models;
using EShop.Core.Domain.Products.Models;
using EShop.Core.Domain.Users.Models;
using EShop.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence;

public class EShopDbContext(DbContextOptions<EShopDbContext> options) : DbContext(options)
{
    internal const string EShopDbSchema = "EShopDb";
    internal const string EShopDbMigrationsHistoryTable = "__eShopDbMigrationsHistory";

    public DbSet<Category> Categories { get; set; }

    public DbSet<CartItem> CartItems { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(EShopDbSchema);
        modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CartItemEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CartEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewEntityTypeConfiguration());
    }
}
