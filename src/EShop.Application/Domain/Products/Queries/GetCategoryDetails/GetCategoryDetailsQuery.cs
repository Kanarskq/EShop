using MediatR;

namespace EShop.Application.Domain.Products.Queries.GetCategoryDetails;

public record GetCategoryDetailsQuery(Guid CategoryId) : IRequest<CategoryDetailsDto>;