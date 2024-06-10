using EShop.Core.Domain.Carts.Models;
using MediatR;

namespace EShop.Application.Domain.Users.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid UserId,
    string UserName,
    string Email,
    string PasswordHash,
    string FirstName,
    string LastName) 
    : IRequest;

