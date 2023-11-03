using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class LoginController : Controller
    {
        public INotyfService _notifyService { get; }

        public LoginController(INotyfService notifyService)
        {
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Acessar(string email, string senha)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Cadastrar(LoginViewModel viewModel)
        {
           return View("Index");
        }
    }
}
