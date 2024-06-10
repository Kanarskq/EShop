using EShop.Application.Domain.Products.Queries.GetProductDetails;
using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Products.Queries.GetCategoryDetails;

public record CategoryDetailsDto
{
    [Required]
    public Guid CategoryId { get; init; }

    [Required]
    public string Name { get; init; }
    public string Description { get; init; }

    [Required]
    public List<ProductDto> Products { get; init; }
}
