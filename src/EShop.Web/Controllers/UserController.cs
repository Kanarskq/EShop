using EShop.Web.Clients;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Web.Controllers;

[Route("[controller]")]
public class UsersController : Controller
{
    private readonly IClient _eShopClient;

    public UsersController(IClient eShopClient)
    {
        _eShopClient = eShopClient;
    }

    [HttpGet("UserDetails/{id}")]
    public async Task<IActionResult> UserDetails(Guid id)
    {
        var user = await _eShopClient.GetUserDetailsAsync(id);
        return View(user);
    }

    [HttpGet("CreateUser")]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost("CreateUserPost")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        await _eShopClient.CreateUserAsync(request);
        return RedirectToAction("UserDetails/{request.UserId}");
    }

    [HttpGet("EditUser/{id}")]
    public async Task<IActionResult> EditUser(Guid id)
    {
        return View();
    }

    [HttpPost("EditUserPost/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(Guid id, UpdateUserRequest request)
    {
        await _eShopClient.UpdateUserAsync(id.ToString(), request);
        return RedirectToAction("UserDetails/{request.UserId}");
    }

    [HttpPost("Delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUser(List<Guid> id)
    {
        await _eShopClient.DeleteUsersAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
