using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EShop.Core.Domain.Carts.Models;

namespace EShop.Persistence.EntityConfigurations;

public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {

        // Primary key
        builder.HasKey(c => c.UserId);

        builder.Property(c => c.CreatedAt)
               .IsRequired();

        builder.Property(c => c.UpdatedAt)
               .IsRequired();

        // Relationships
        builder.HasOne(c => c.User)
               .WithOne()
               .HasForeignKey<Cart>(c => c.UserId);

        builder.HasMany(c => c.Items)
               .WithOne()
               .HasForeignKey(ci => ci.CartItemId);
    }
}
