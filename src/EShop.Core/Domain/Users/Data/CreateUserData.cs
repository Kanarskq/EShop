namespace EShop.Core.Domain.Users.Data;

public record CreateUserData(
    string UserName,
    string Email,
    string PasswordHash,
    string FirstName,
    string LastName)
{
}
