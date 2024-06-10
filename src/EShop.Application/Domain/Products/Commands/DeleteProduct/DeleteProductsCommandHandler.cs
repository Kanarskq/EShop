using EShop.Core.Common;
using EShop.Core.Domain.Products.Common;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.DeleteProduct;

public class DeleteProductsCommandHandler(
    IProductsRepository productRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductsCommand>
{
    public async Task Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await productRepository.FindManyAsync(request.Ids, cancellationToken);

        productRepository.Delete(products);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
