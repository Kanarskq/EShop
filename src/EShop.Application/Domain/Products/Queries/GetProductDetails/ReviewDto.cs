using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Products.Queries.GetProductDetails;

public record ReviewDto
{
    [Required]
    public Guid UserId { get; init; }

    public string Comment { get; init; }

    [Required]
    public int Rating { get; init; }

    [Required]
    public DateTime CreatedAt { get; init; }

}
