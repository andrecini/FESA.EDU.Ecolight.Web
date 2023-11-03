using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.Ecolight.Web.FRONTEND.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public INotyfService _notifyService { get; }

        public HomeController(ILogger<HomeController> logger, INotyfService notifyService)
        {
            _logger = logger;
            _notifyService= notifyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
