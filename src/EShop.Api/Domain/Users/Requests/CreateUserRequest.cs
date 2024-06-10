namespace EShop.Api.Domain.Users.Requests;

public record CreateUserRequest(
    string UserName,
    string Email,
    string PasswordHash,
    string FirstName,
    string LastName);
