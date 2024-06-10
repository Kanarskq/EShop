using MediatR;

namespace EShop.Application.Domain.Products.Commands.DeleteProduct;

public record DeleteProductsCommand(IReadOnlyCollection<Guid> Ids) : IRequest;
