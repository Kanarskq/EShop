using EShop.Core.Domain.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Persistence.EntityConfigurations;

public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        // Primary key
        builder.HasKey(r => r.UserId);

        builder.HasKey(r => r.ProductId);

        builder.Property(r => r.Comment)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(r => r.Rating)
               .IsRequired();

        builder.Property(r => r.CreatedAt)
               .IsRequired();

        builder.Property(r => r.UpdatedAt)
               .IsRequired();

        // Relationships
        builder.HasOne(r => r.User)
               .WithMany(u => u.Reviews)
               .HasForeignKey(r => r.UserId);

        builder.HasOne(r => r.Product)
               .WithMany(p => p.Reviews)
               .HasForeignKey(r => r.ProductId);
    }
}
