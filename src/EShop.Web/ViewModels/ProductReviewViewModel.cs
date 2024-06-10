using EShop.Web.Clients;

namespace EShop.Web.ViewModels;

public class ProductReviewViewModel
{
    public Guid ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public Guid CategoryId { get; set; }

    public byte[] ImageData { get; set; }

    public string ImageBase64
    {
        get
        {
            if (ImageData != null && ImageData.Length > 0)
            {
                return Convert.ToBase64String(ImageData);
            }
            return string.Empty;
        }
    }

    public List<ReviewViewModel> Reviews { get; set; }
}
