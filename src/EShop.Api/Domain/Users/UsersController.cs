using EShop.Api.Common;
using EShop.Api.Constants;
using EShop.Api.Domain.Users.Requests;
using EShop.Application.Domain.Users.Commands.CreateUser;
using EShop.Application.Domain.Users.Commands.DeleteUser;
using EShop.Application.Domain.Users.Commands.UpdateUser;
using EShop.Application.Domain.Users.Queries.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EShop.Api.Domain.Users
{
    [Route(Routes.Users)]
    public class UsersController(IMediator mediator) : ApiControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserDetailsAsync(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken = default)
        {
            var query = new GetUserDetailsQuery(userId);
            var user = await mediator.Send(query, cancellationToken);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateUserCommand(request.UserName, request.Email, request.PasswordHash, request.FirstName, request.LastName);
            var result = await mediator.Send(command, cancellationToken);
            return Created(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(
        [FromBody][Required] UpdateUserRequest request,
        CancellationToken cancellationToken = default)
        {
            var command = new UpdateUserCommand(request.UserId, request.UserName, request.Email, request.PasswordHash, request.FirstName, request.LastName);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsersAsync(
        [FromQuery][Required] IReadOnlyCollection<Guid> ids,
        CancellationToken cancellationToken = default)
        {
            var command = new DeleteUsersCommand(ids);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
