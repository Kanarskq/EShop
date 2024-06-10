using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Carts.Queries.GetCartDetails;

public record CartItemDto
{
    [Required]
    public Guid ProductId { get; init; }
    [Required]
    public int Quantity { get; init; }
    [Required]
    public decimal Price { get; init; }
}
