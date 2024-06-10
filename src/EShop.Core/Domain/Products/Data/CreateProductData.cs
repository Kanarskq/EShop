namespace EShop.Core.Domain.Products.Data;
public record CreateProductData(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    Guid CategoryId,
    byte[] ImageData)
{ }

