using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EShop.Core.Domain.Carts.Models;

namespace EShop.Persistence.EntityConfigurations;

public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        // Primary key
        builder.HasKey(ci => ci.CartItemId);

        builder.Property(ci => ci.ProductId)
               .IsRequired();

        builder.Property(ci => ci.Quantity)
               .IsRequired();

        builder.Property(ci => ci.Price)
               .IsRequired();

        // Relationships
        builder.HasOne(ci => ci.Product)
               .WithMany()
               .HasForeignKey(ci => ci.ProductId);
    }
}