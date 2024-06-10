using EShop.Core.Domain.Carts.Validators;
using EShop.Core.Common;
using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Products.Models;

namespace EShop.Core.Domain.Carts.Models;

public class CartItem : Entity, IAggregateRoot
{
    private CartItem()
    {
    }

    public Guid CartItemId { get; private set; }

    public Guid ProductId { get; private set; }

    public Product Product { get; private set; }

    public int Quantity { get; private set; }

    public decimal Price { get; private set; }

    public static CartItem Create(IProductMustExistChecker productMustExistChecker, CreateCartItemData createCartItemData)
    {
        ValidateAsync(new CreateCartItemValidator(productMustExistChecker), createCartItemData);

        return new CartItem
        {
            CartItemId = Guid.NewGuid(),
            ProductId = createCartItemData.ProductId,
            Quantity = createCartItemData.Quantity,
            Price = createCartItemData.Price,
        };
    }

    public void Update(IProductMustExistChecker productMustExistChecker, UpdateCartItemData updateCartItemData)
    {
        ValidateAsync(new UpdateCartItemValidator(productMustExistChecker), updateCartItemData);

        Quantity = updateCartItemData.Quantity;
        Price = updateCartItemData.Price;
    }
}
