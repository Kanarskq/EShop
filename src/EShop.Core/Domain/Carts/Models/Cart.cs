using EShop.Core.Common;
using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Carts.Validators;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Users.Models;

namespace EShop.Core.Domain.Carts.Models;

public class Cart : Entity, IAggregateRoot
{
    private Cart()
    {
    }

    public Guid UserId { get; private set; }

    public User User { get; private set; }

    public List<CartItem> Items { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public static Cart Create(IUserMustExistChecker userMustExistChecker, CreateCartData createCartData)
    {
        ValidateAsync(new CreateCartValidator(userMustExistChecker), createCartData);

        return new Cart
        {
            UserId = createCartData.UserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public void Update(IUserMustExistChecker userMustExistChecker, UpdateCartData updateCartData)
    {
        ValidateAsync(new UpdateCartValidator(userMustExistChecker), updateCartData);

        Items = updateCartData.Items;
        UpdatedAt = DateTime.UtcNow;
    }
}
