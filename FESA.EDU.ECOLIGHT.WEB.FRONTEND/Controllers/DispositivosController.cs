using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Dispositivo;
using Microsoft.AspNetCore.Mvc;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class DispositivosController : Controller
    {
        public INotyfService _notifyService { get; }

        public DispositivosController(INotyfService notifyService)
        {
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Cadastrar(DispositivoViewModel viewModel)
        {
            _notifyService.Success("Dispositivo cadastrado com sucesso!");

            return View("Index");
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Editar(DispositivoViewModel viewModel)
        {
            _notifyService.Success("Dispositivo alterado com sucesso!");

            return View("Detalhes");
        }

    }
}
