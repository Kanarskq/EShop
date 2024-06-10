namespace EShop.Api.Domain.Products.Requests;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    Guid CategoryId,
    IFormFile ImageFile
);
