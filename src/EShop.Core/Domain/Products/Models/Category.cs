using EShop.Core.Domain.Products.Validators;
using EShop.Core.Common;
using EShop.Core.Domain.Products.Data;

namespace EShop.Core.Domain.Products.Models;

public class Category : Entity, IAggregateRoot
{
    private Category()
    {
    }

    public Guid CategoryId { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public List<Product> Products { get; private set; }

    public static Category Create(CreateCategoryData data)
    {
        Validate(new CreateCategoryValidator(), data);

        return new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = data.Name,
            Description = data.Description
        };
    }

    public void Update(UpdateCategoryData data)
    {
        Validate(new UpdateCategoryValidator(), data);

        Name = data.Name;
        Description = data.Description;
    }
}
