using EShop.Core.Domain.Carts.Models;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.UpdateCart;

public record UpdateReviewCommand(
    Guid UserId,
    Guid ProductId,
    string Comment,
    int Rating) 
    : IRequest;
