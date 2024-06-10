namespace EShop.Core.Domain.Users.Data;

public record UpdateUserData(
    string UserName,
    string Email,
    string PasswordHash,
    string FirstName,
    string LastName)
{
}
