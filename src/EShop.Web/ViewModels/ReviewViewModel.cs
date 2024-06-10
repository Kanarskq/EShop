namespace EShop.Web.ViewModels;

public class ReviewViewModel
{
    public Guid UserId { get; set; }

    public string UserName { get; set; }

    public Guid ProductId { get; set; }

    public string ProductName { get; set; }

    public string Comment { get; set; }

    public int Rating { get; set; }
}
