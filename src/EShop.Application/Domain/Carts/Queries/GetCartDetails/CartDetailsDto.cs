using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Carts.Queries.GetCartDetails;

public record CartDetailsDto
{
    [Required]
    public Guid UserId { get; init; }
    public List<CartItemDto> Items { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }


}
