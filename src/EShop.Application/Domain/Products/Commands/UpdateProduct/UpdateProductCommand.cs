using EShop.Core.Domain.Carts.Models;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid ProductId,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    Guid CategoryId,
    byte[] ImageData) : IRequest;
