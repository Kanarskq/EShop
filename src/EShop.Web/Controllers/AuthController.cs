using EShop.Web.Clients;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EShop.Web.Controllers;

public class AuthController : Controller
{
    private readonly IClient _eShopClient;

    public AuthController(IClient eShopClient)
    {
        _eShopClient = eShopClient;
    }

    public async Task<IActionResult> Login(string returnUrl = "https://localhost:7086/")
    {
        await _eShopClient.LoginAsync(returnUrl);
        return new EmptyResult(); // Authentication middleware handles the redirect.
    }

    [Authorize]
    public async Task<IActionResult> Profile()
    {
        await _eShopClient.ProfileAsync();
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var idToken = await HttpContext.GetTokenAsync("id_token");

        var profile = new
        {
            User.Identity.Name,
            EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
            ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
            Roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value),
            AccessToken = accessToken,
            IdToken = idToken
        };

        return View(profile); // Assuming you have a view to display the profile
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _eShopClient.LogoutAsync();
        return Redirect("https://localhost:7105/"); 
    }
}
