using EShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EShop.Web.Controllers;

[Route("/")]
public class HomeController() : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("about")]
    public IActionResult About()
    {
        ViewData["Message"] = "Description of your application";
        return View();
    }

    [HttpGet("contact")]
    public IActionResult Contact()
    {
        ViewData["Message"] = "Your app's contact page";
        return View();
    }

    [HttpGet("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
