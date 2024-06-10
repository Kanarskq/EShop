using EShop.Core.Common;
using EShop.Core.Domain.Carts.Common;
using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Data;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(
    IProductsRepository productRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateProductCommand>
{

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.FindAsync(request.ProductId, cancellationToken);

        var updateProductData = new UpdateProductData(
            request.Name,
            request.Description,
            request.Price,
            request.Stock,
            request.CategoryId,
            request.ImageData);

        product.Update(updateProductData);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
