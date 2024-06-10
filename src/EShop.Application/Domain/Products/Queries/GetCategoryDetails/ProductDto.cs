using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Products.Queries.GetCategoryDetails;

public record ProductDto
{
    [Required]
    public Guid ProductId { get; init; }

    [Required]
    public string Name { get; init; }

    [Required]
    public string Description { get; init; }

    [Required]
    public decimal Price { get; init; }

    [Required]
    public int Stock { get; init; }

    [Required] 
    public Guid CategoryId { get; init; }

    [Required]
    public byte[] ImageData { get; init; }
}
