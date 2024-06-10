using EShop.Core.Domain.Carts.Models;
using MediatR;

namespace EShop.Application.Domain.Users.Commands.CreateUser;

public record CreateUserCommand(
    string UserName,
    string Email,
    string PasswordHash,
    string FirstName,
    string LastName): IRequest<Guid>;
