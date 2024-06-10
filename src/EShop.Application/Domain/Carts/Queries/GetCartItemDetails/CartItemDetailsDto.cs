using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Carts.Queries.GetCartItemDetails;

public record CartItemDetailsDto
{
    [Required]
    public Guid CartItemId { get; init; }

    [Required]
    public Guid ProductId { get; init; }

    [Required]
    public int Quantity { get; init; }

    [Required]
    public decimal Price { get; init; }
}
