using EShop.Core.Common;
using EShop.Core.Domain.Products.Common;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.DeleteCategory;

public class DeleteCategoriesCommandHandler(
    ICategoriesRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoriesCommand>
{
    public async Task Handle(DeleteCategoriesCommand request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.FindManyAsync(request.Ids, cancellationToken);

        categoryRepository.Delete(categories);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
