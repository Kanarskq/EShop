namespace EShop.Web.ViewModels;

public class CategoryDetailsViewModel
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<ProductViewModel> Products { get; set; }
}
