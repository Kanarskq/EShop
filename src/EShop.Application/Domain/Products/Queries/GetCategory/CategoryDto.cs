using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Products.Queries.GetCategory;

public record CategoryDto
{
    [Required]
    public Guid CategoryId { get; init; }

    [Required]
    public string Name { get; init; }

    public string Description { get; init; }
}
