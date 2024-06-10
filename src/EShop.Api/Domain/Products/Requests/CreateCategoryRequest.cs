namespace EShop.Api.Domain.Products.Requests;

public record CreateCategoryRequest(
    string Name,
    string Description);
