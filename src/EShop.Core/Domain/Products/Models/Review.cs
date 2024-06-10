using EShop.Core.Common;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Products.Data;
using EShop.Core.Domain.Products.Validators;
using EShop.Core.Domain.Users.Models;

namespace EShop.Core.Domain.Products.Models;

public class Review : Entity, IAggregateRoot
{

    private Review()
    {
    }

    public Guid UserId { get; private set; }

    public User User { get; private set; }

    public Guid ProductId { get; private set; }

    public Product Product { get; private set; }

    public string Comment { get; private set; }

    public int Rating { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }


    public static Review Create(
        IProductMustExistChecker productMustExistChecker,
        IUserMustExistChecker userMustExistChecker,
        CreateReviewData createReviewData)
    {
        ValidateAsync(new CreateReviewValidator(productMustExistChecker, userMustExistChecker), createReviewData);

        return new Review
        {
            UserId = createReviewData.UserId,
            ProductId = createReviewData.ProductId,
            Comment = createReviewData.Comment,
            Rating = createReviewData.Rating,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public void Update(
        IProductMustExistChecker productMustExistChecker,
        IUserMustExistChecker userMustExistChecker,
        UpdateReviewData updateReviewData)
    {
        ValidateAsync(new UpdateReviewValidator(productMustExistChecker, userMustExistChecker), updateReviewData);

        Comment = updateReviewData.Comment;
        Rating = updateReviewData.Rating;
        UpdatedAt = DateTime.UtcNow;
    }
}

