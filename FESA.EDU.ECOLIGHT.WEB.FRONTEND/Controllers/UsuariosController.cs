using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class UsuariosController : Controller
    {
        public INotyfService _notifyService { get; }

        public UsuariosController(INotyfService notifyService)
        {
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Editar(UsuariosViewModel viewModel)
        {
            _notifyService.Success("Dados do Usuário alterados com sucesso!");

            return View("Index");
        }
    }
}
