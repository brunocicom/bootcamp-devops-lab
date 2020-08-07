using System.Diagnostics;
using BootcampDevOpsLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BootcampDevOpsLab.Services.Interfaces;

namespace BootcampDevOpsLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMathService _mathService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IMathService mathService,
            ILogger<HomeController> logger)
        {
            _logger = logger;
            _mathService = mathService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(decimal milhas)
        {
            ViewData["milhas"] = milhas;
            ViewBag.Quilometros = _mathService.Multiply(milhas, 1.6m);
            return View();
        }

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
}