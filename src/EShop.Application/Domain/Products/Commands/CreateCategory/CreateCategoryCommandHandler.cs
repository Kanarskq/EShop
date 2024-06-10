using EShop.Core.Common;
using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Data;
using EShop.Core.Domain.Products.Models;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.CreateCategory;

public class CreateCategoryCommandHandler(
    ICategoriesRepository categoryRepository, 
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var createCategoryData = new CreateCategoryData
        (
            request.Name,
            request.Description
        );

        var category = Category.Create(createCategoryData);

        categoryRepository.Add(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.CategoryId;
    }

}
