using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Products.Queries.GetReview;

public record ReviewDto
{
    [Required]
    public Guid UserId { get; init; }

    [Required]
    public Guid ProductId { get; init; }

    public string Comment { get; init; }

    [Required]
    public int Rating { get; init; }

    [Required]
    public DateTime CreatedAt { get; init; }

    [Required]
    public DateTime UpdatedAt { get; init; }
}
