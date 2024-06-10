namespace EShop.Web.ViewModels;

public class UserViewModel
{
    Guid UserId { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public List<ReviewViewModel> Reviews { get; set; }
}
