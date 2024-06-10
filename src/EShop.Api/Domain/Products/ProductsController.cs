using EShop.Api.Common;
using EShop.Api.Constants;
using EShop.Api.Domain.Products.Requests;
using EShop.Application.Domain.Products.Commands.CreateCategory;
using EShop.Application.Domain.Products.Commands.CreateProduct;
using EShop.Application.Domain.Products.Commands.CreateReview;
using EShop.Application.Domain.Products.Commands.DeleteCategory;
using EShop.Application.Domain.Products.Commands.DeleteProduct;
using EShop.Application.Domain.Products.Commands.DeleteReview;
using EShop.Application.Domain.Products.Commands.UpdateCategory;
using EShop.Application.Domain.Products.Commands.UpdateProduct;
using EShop.Application.Domain.Products.Queries.GetCategory;
using EShop.Application.Domain.Products.Queries.GetCategoryDetails;
using EShop.Application.Domain.Products.Queries.GetProductDetails;
using EShop.Application.Domain.Products.Queries.GetReview;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace EShop.Api.Domain.Products
{
    [Route(Routes.Products)]
    public class ProductsController(IMediator mediator) : ApiControllerBase
    {
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategoriesAsync(
            CancellationToken cancellationToken = default)
        {
            var query = new GetCategoriesQuery();
            var categories = await mediator.Send(query, cancellationToken);
            return Ok(categories);
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<IActionResult> GetCategoryDetailsAsync(
            [FromRoute] Guid categoryId,
            CancellationToken cancellationToken = default)
        {
            var query = new GetCategoryDetailsQuery(categoryId);
            var category = await mediator.Send(query, cancellationToken);
            return Ok(category);
        }

        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetProductDetailsAsync(
            [FromRoute] Guid productId,
            CancellationToken cancellationToken = default)
        {
            var query = new GetProductDetailsQuery(productId);
            var product = await mediator.Send(query, cancellationToken);
            return Ok(product);
        }

        [HttpGet("products/{productId}/reviews")]
        public async Task<IActionResult> GetReviewsAsync(
            [FromRoute] Guid productId,
            CancellationToken cancellationToken = default)
        {
            var query = new GetReviewsQuery(productId);
            var cartItem = await mediator.Send(query, cancellationToken);
            return Ok(cartItem);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategoryAsync(
            [FromBody] CreateCategoryRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateCategoryCommand(request.Name, request.Description);
            var result = await mediator.Send(command, cancellationToken);
            return Created(result);
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProductAsync(
            [FromForm] CreateProductRequest request,
            CancellationToken cancellationToken = default)
        {
            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                await request.ImageFile.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }

            var command = new CreateProductCommand(
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.CategoryId,
                imageData);

            var result = await mediator.Send(command, cancellationToken);
            return Created(result);
        }


        [HttpPost("products/{productId}/reviews")]
        public async Task<IActionResult> CreateReviewAsync(
            [FromBody] CreateReviewRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateReviewCommand(request.UserId, request.ProductId, request.Comment, request.Rating);
            var result = await mediator.Send(command, cancellationToken);
            return Created(result);
        }

        [HttpPut("categories/{categoryId}")]
        public async Task<IActionResult> UpdateCategoryAsync(
        [FromBody][Required] UpdateCategoryRequest request,
        CancellationToken cancellationToken = default)
        {
            var command = new UpdateCategoryCommand(request.CategoryId, request.Name, request.Description);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpPut("products/{productId}")]
        public async Task<IActionResult> UpdateProductAsync(
        [FromBody][Required] UpdateProductRequest request,
        CancellationToken cancellationToken = default)
        {
            var command = new UpdateProductCommand(request.ProductId, request.Name, request.Description, request.Price, request.Stock, request.CategoryId, request.ImageData);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("categories")]
        public async Task<IActionResult> DeleteCategoriesAsync(
        [FromQuery][Required] IReadOnlyCollection<Guid> ids,
        CancellationToken cancellationToken = default)
        {
            var command = new DeleteCategoriesCommand(ids);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("products")]
        public async Task<IActionResult> DeleteProductsAsync(
        [FromQuery][Required] IReadOnlyCollection<Guid> ids,
        CancellationToken cancellationToken = default)
        {
            var command = new DeleteProductsCommand(ids);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("products/{productId}/reviews")]
        public async Task<IActionResult> DeleteReviewAsync(
        [FromQuery][Required] Guid userId,
        [FromQuery][Required] Guid productId,
        CancellationToken cancellationToken = default)
        {
            var command = new DeleteReviewCommand(userId, productId);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
