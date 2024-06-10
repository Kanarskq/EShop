using EShop.Core.Domain.Carts.Models;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    Guid CategoryId,
    string Name,
    string Description)
    : IRequest;
