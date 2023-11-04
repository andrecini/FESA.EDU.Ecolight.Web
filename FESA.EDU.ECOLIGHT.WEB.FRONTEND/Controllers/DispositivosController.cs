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
            if (!Validar(viewModel))
                return View("Cadastro");
            

            _notifyService.Success("Dispositivo cadastrado com sucesso!");

            return View("Index");
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Editar(DispositivoViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Detalhes");

            _notifyService.Success("Dispositivo alterado com sucesso!");

            return View("Detalhes");
        }

        private bool Validar(DispositivoViewModel viewModel)
        {
            var validator = new DispositivoViewModelValidator();

            var results = validator.Validate(viewModel);

            if (results.IsValid)
            {
                return true;
            }

            var erros = results.Errors;

            foreach (var erro in erros)
            {
                _notifyService.Warning(erro.ErrorMessage);
            }

            return false;
        }

    }
}
