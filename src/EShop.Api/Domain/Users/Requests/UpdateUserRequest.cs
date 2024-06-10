namespace EShop.Api.Domain.Users.Requests;

public record UpdateUserRequest(
    Guid UserId,
    string UserName,
    string Email,
    string PasswordHash,
    string FirstName,
    string LastName);
