using EShop.Core.Domain.Users.Validators;
using EShop.Core.Common;
using EShop.Core.Domain.Products.Models;
using EShop.Core.Domain.Users.Data;

namespace EShop.Core.Domain.Users.Models;

public class User : Entity, IAggregateRoot
{
    private readonly List<Review> _reviews = [];

    private User()
    {
    }

    public Guid UserId { get; private set; }

    public string UserName { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

    public static User Create(CreateUserData createUserData)
    {
        Validate(new CreateUserValidator(), createUserData);

        return new User
        {
            UserId = new Guid(),
            UserName = createUserData.UserName,
            Email = createUserData.Email,
            PasswordHash = createUserData.PasswordHash,
            FirstName = createUserData.FirstName,
            LastName = createUserData.LastName,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public void Update(UpdateUserData updateUserData)
    {
        Validate(new UpdateUserValidator(), updateUserData);

        UserName = updateUserData.UserName;
        Email = updateUserData.Email;
        PasswordHash = updateUserData.PasswordHash;
        FirstName = updateUserData.FirstName;
        LastName = updateUserData.LastName;
    }
}
