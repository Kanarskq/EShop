using EShop.Application.Domain.Products.Queries.GetReview;
using MediatR;

namespace EShop.Application.Domain.Products.Queries.GetProductDetails;

public record GetProductDetailsQuery(Guid ProductId) : IRequest<ProductDto>;