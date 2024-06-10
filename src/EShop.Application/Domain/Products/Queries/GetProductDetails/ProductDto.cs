namespace EShop.Application.Domain.Products.Queries.GetProductDetails;

public record ProductDto
{
    public Guid ProductId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int Stock { get; init; }
    public Guid CategoryId { get; init; }
    public string CategoryName { get; init; }
    public byte[] ImageData { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public List<ReviewDto> Reviews { get; init; }
}
