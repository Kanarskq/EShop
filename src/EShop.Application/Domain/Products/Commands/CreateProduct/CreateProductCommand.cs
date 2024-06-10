using MediatR;

namespace EShop.Application.Domain.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    Guid CategoryId,
    byte[] ImageData) : IRequest<Guid>;

