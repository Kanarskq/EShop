using EShop.Core.Common;
using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Data;
using EShop.Core.Domain.Products.Models;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(
    ICategoriesRepository categoryRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateCategoryCommand>
{
    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.FindAsync(request.CategoryId, cancellationToken);

        var updateCategoryData = new UpdateCategoryData(request.Name, request.Description);

        category.Update(updateCategoryData);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
