using MediatR;

namespace EShop.Application.Domain.Products.Queries.GetCategory;

public record GetCategoriesQuery() : IRequest<List<CategoryDto>>;
