using MediatR;

namespace EShop.Application.Domain.Products.Commands.CreateCategory;

public record CreateCategoryCommand(
    string Name,
    string Description) : IRequest<Guid>;

