using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApplication.Models;

namespace MyApplication.Controllers;

// Attributes applied at this level will apply by default to all other methods
// - unless those methods have their own attribute, which overrides the setting.
//
// Don't specify role and as long as you are in one, you will have access
[Authorize] 
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    // The role will align with the 'value' of your App Roles in Entra.
    // Here, we'd need to be assigned the 'Site.Admin' role in order to
    // be able to visit this page.
    [Authorize(Roles = "Site.Admin")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}