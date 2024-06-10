using EShop.Web.Clients;
using EShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace EShop.Web.Controllers;

[Route("products")]
public class ProductsController : Controller
{
    private readonly IClient _eShopClient;

    public ProductsController(IClient eShopClient)
    {
        _eShopClient = eShopClient;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var categories = await _eShopClient.GetCategoriesAsync();
        return View(categories);
    }

    [HttpGet("CategoryDetails/{categoryId}")]
    public async Task<IActionResult> CategoryDetails([FromRoute] Guid categoryId)
    {
        var category = await _eShopClient.GetCategoryDetailsAsync(categoryId);
        return View(category);
    }

    [HttpGet("ProductDetails/{productId}")]
    public async Task<IActionResult> ProductDetails([FromRoute] Guid productId)
    {
        var product = await _eShopClient.GetProductDetailsAsync(productId);
        var reviews = await _eShopClient.GetReviewsAsync(productId);

        var reviewViewModels = new List<ReviewViewModel>();

        foreach (var review in reviews)
        {
            var user = await _eShopClient.GetUserDetailsAsync(review.UserId);

            var reviewViewModel = new ReviewViewModel
            {
                UserId = review.UserId,
                UserName = user.UserName,
                ProductId = review.ProductId,
                Rating = review.Rating,
                Comment = review.Comment
            };

            reviewViewModels.Add(reviewViewModel);
        }

        var productReviewViewModel = new ProductReviewViewModel
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            ImageData = product.ImageData,
            Reviews = reviewViewModels
        };

        return View(productReviewViewModel);
    }

    [HttpGet("Reviews/{productId}")]
    public async Task<IActionResult> Reviews(Guid productId)
    {
        var reviews = await _eShopClient.GetReviewsAsync(productId);

        var reviewViewModels = new List<ReviewViewModel>();

        foreach (var review in reviews)
        {
            var user = await _eShopClient.GetUserDetailsAsync(review.UserId);

            var reviewViewModel = new ReviewViewModel
            {
                UserId = review.UserId,
                UserName = user.UserName,
                ProductId = review.ProductId,
                Rating = review.Rating,
                Comment = review.Comment
            };

            reviewViewModels.Add(reviewViewModel);
        }

        return View(reviewViewModels);
    }

    [HttpGet("CreateCategory")]
    public IActionResult CreateCategory()
    {
        return View();
    }


    [HttpPost("CreateCategoryPost")]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
    {
        await _eShopClient.CreateCategoryAsync(request);
        return RedirectToAction("Index");
    }

    [HttpGet("CreateProduct")]
    public async Task<IActionResult> CreateProduct()
    {
        var categories = await _eShopClient.GetCategoriesAsync();
        var viewModel = new CreateProductViewModel
        {
            Categories = categories.Select(c => new CategoryViewModel
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToList()
        };

        return View(viewModel);
    }
    
    [HttpPost("CreateProductPost")]
    public async Task<IActionResult> CreateProduct(string name, string description, double? price, int? stock, Guid? categoryId, IFormFile imageFile)
    {
        var fileParameter = new FileParameter(imageFile.OpenReadStream());
        await _eShopClient.CreateProductAsync(name, description, price, stock, categoryId, fileParameter);
        return RedirectToAction("Index");
    }

    [HttpGet("CreateReview")]
    public async Task<IActionResult> CreateReview(Guid productId)
    {
        var model = new ReviewViewModel
        {
            ProductId = productId
        };
        return View(model);
    }

    [HttpPost("CreateReview")]
    public async Task<IActionResult> CreateReview(CreateReviewRequest request)
    {
        await _eShopClient.CreateReviewAsync(request.ProductId.ToString(), request);
        return RedirectToAction("ProductDetails", new { productId = request.ProductId });
    }

    [HttpGet("UpdateCategory/{categoryId}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] Guid categoryId)
    {
        var category = await _eShopClient.GetCategoryDetailsAsync(categoryId);
        return View(category);
    }

    [HttpPost("UpdateCategoryPost")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
    {
        await _eShopClient.UpdateCategoryAsync(request.CategoryId.ToString(), request);
        return RedirectToAction("CategoryDetails", new { categoryId = request.CategoryId });
    }

    [HttpGet("UpdateProduct/{productId}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid productId)
    {
        var product = await _eShopClient.GetProductDetailsAsync(productId);
        var categories = await _eShopClient.GetCategoriesAsync();

        var updateProductRequest = new UpdateProductRequestViewModel
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImageData = product.ImageData,
            CategoryId = product.CategoryId,
            Categories = categories
        };

        return View(updateProductRequest);
    }

    [HttpPost("UpdateProductPost")]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequestViewModel model)
    {
        
            if (model.ImageFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    await model.ImageFile.CopyToAsync(ms);
                    model.ImageData = ms.ToArray();
                }
            }

            var updateProductRequest = new UpdateProductRequest
            {
                ProductId = model.ProductId,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId,
                ImageData = model.ImageData
            };

            await _eShopClient.UpdateProductAsync(updateProductRequest.ProductId.ToString(), updateProductRequest);
            return RedirectToAction("ProductDetails", new { productId = model.ProductId });
    }

    [HttpPost("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        await _eShopClient.DeleteCategoriesAsync(new List<Guid> { categoryId });
        return RedirectToAction("Index");
    }

    [HttpPost("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        await _eShopClient.DeleteProductsAsync(new List<Guid> { productId });
        return RedirectToAction("Index");
    }

    [HttpPost("DeleteReview")]
    public async Task<IActionResult> DeleteReview(Guid userId, Guid productId)
    {
        await _eShopClient.DeleteReviewAsync(userId, productId, productId.ToString());
        return RedirectToAction("ProductDetails", new { productId });
    }
}
