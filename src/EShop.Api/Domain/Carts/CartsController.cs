using EShop.Api.Common;
using EShop.Api.Constants;
using EShop.Api.Domain.Carts.Requests;
using EShop.Application.Domain.Carts.Commands.CreateCart;
using EShop.Application.Domain.Carts.Commands.CreateCartItem;
using EShop.Application.Domain.Carts.Commands.DeleteCart;
using EShop.Application.Domain.Carts.Commands.DeleteCartItem;
using EShop.Application.Domain.Carts.Commands.UpdateCart;
using EShop.Application.Domain.Carts.Commands.UpdateCartItem;
using EShop.Application.Domain.Carts.Queries.GetCartDetails;
using EShop.Application.Domain.Carts.Queries.GetCartItemDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EShop.Api.Domain.Carts
{
    [Route(Routes.Carts)]

    public class CartsController(IMediator mediator) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCartAsync(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken = default)
        {
            var query = new GetCartDetailsQuery(userId);
            var cart = await mediator.Send(query, cancellationToken);
            return Ok(cart);
        }

        [HttpGet("{cartItemId}")]
        public async Task<IActionResult> GetCartItemDetailsAsync(
            [FromRoute] Guid cartItemId,
            CancellationToken cancellationToken = default)
        {
            var query = new GetCartItemDetailsQuery(cartItemId);
            var cartItem = await mediator.Send(query, cancellationToken);
            return Ok(cartItem);
        }

        [HttpPost("create-cart")]
        public async Task<IActionResult> CreateCartAsync(
            [FromBody] CreateCartRequest request, 
            CancellationToken cancellationToken = default)
        {
            var command = new CreateCartCommand(request.UserId);
            var result = await mediator.Send(command, cancellationToken);
            return Created(result);
        }

        [HttpPost("create-cart-item")]
        public async Task<IActionResult> CreateCartItemAsync(
            [FromBody] CreateCartItemRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateCartItemCommand(request.ProductId, request.Quantity, request.Price);
            var result = await mediator.Send(command, cancellationToken);
            return Created(result);
        }

        [HttpPut("update-cart/{userId}")]
        public async Task<IActionResult> UpdateCartAsync(
        [FromRoute][Required] Guid userId,
        [FromBody][Required] UpdateCartRequest request,
        CancellationToken cancellationToken = default)
        {
            var command = new UpdateCartCommand(userId, request.Items);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpPut("update-cart-item/{cartItemId}")]
        public async Task<IActionResult> UpdateCartItemAsync(
        [FromBody][Required] UpdateCartItemRequest request,
        CancellationToken cancellationToken = default)
        {
            var command = new UpdateCartItemCommand(request.CartItemId, request.ProductId, request.Quantity, request.Price);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("delete-carts")]
        public async Task<IActionResult> DeleteCartsAsync(
        [FromQuery][Required] IReadOnlyCollection<Guid> ids,
        CancellationToken cancellationToken = default)
        {
            var command = new DeleteCartsCommand(ids);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("delete-cart-items")]
        public async Task<IActionResult> DeleteCartItemsAsync(
        [FromQuery][Required] IReadOnlyCollection<Guid> ids,
        CancellationToken cancellationToken = default)
        {
            var command = new DeleteCartItemsCommand(ids);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
