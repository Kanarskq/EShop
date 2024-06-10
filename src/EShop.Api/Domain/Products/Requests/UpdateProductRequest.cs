namespace EShop.Api.Domain.Products.Requests;

public record UpdateProductRequest(
    Guid ProductId,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    Guid CategoryId,
    byte[] ImageData);

