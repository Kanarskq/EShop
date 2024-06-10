using MediatR;

namespace EShop.Application.Domain.Products.Commands.DeleteCategory;

public record DeleteCategoriesCommand(IReadOnlyCollection<Guid> Ids) : IRequest;