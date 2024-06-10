using EShop.Core.Common;
using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Data;
using EShop.Core.Domain.Products.Models;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IProductsRepository productRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var createProductData = new CreateProductData
        (
            request.Name,
            request.Description,
            request.Price,
            request.Stock,
            request.CategoryId,
            request.ImageData

        );

        var product = Product.Create(createProductData);

        productRepository.Add(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return product.ProductId;
    }

}
