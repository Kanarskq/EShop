using EShop.Core.Common;
using EShop.Core.Domain.Products.Data;
using EShop.Core.Domain.Products.Validators;


namespace EShop.Core.Domain.Products.Models;

public class Product : Entity, IAggregateRoot
{
    private readonly List<Review> _reviews = [];

    private Product()
    {
    }

    public Guid ProductId { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public int Stock { get; private set; }

    public Guid CategoryId { get; private set; }

    public Category Category { get; private set; }

    public byte[] ImageData { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

    public static Product Create(CreateProductData createProductData)
    {
        Validate(new CreateProductValidator(), createProductData);

        return new Product
        {
            ProductId = new Guid(),
            Name = createProductData.Name,
            Description = createProductData.Description,
            Price = createProductData.Price,
            Stock = createProductData.Stock,
            CategoryId = createProductData.CategoryId,
            ImageData = createProductData.ImageData,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public void Update(UpdateProductData updateProductData)
    {
        Validate(new UpdateProductValidator(), updateProductData);

        Name = updateProductData.Name;
        Description = updateProductData.Description;
        Price = updateProductData.Price;
        Stock = updateProductData.Stock;
        CategoryId = updateProductData.CategoryId;
        ImageData = updateProductData.ImageData;
        UpdatedAt = DateTime.UtcNow;
    }
}
