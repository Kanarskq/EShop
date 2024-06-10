using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Domain.Users.Queries.GetUserDetails;

public record UserDetailsDto
{
    [Required]
    public Guid UserId { get; init; }

    [Required]
    public string UserName { get; init; }

    [Required]
    public string Email { get; init; }

    [Required]
    public string FirstName { get; init; }

    [Required]
    public string LastName { get; init; }

    [Required]
    public DateTime CreatedAt { get; init; }
}
