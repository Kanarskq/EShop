namespace EShop.Api.Domain.Products.Requests;

public record UpdateCategoryRequest(
    Guid CategoryId,
    string Name,
    string Description);

