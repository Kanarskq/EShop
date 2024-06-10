namespace EShop.Web.ViewModels;

public class CreateProductViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
    public IFormFile ImageFile { get; set; }
    public List<CategoryViewModel> Categories { get; set; }
}
