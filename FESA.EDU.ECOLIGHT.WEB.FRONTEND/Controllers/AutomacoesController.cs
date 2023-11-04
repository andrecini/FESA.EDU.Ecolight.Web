using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using Microsoft.AspNetCore.Mvc;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class AutomacoesController : Controller
    {
        public INotyfService _notifyService { get; }

        public AutomacoesController(INotyfService notifyService)
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

        public IActionResult Cadastrar(AutomacaoViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Cadastro");

            _notifyService.Success("Automação cadastrada com sucesso!");

            return View("Index");
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Editar(AutomacaoViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Detalhes");

            _notifyService.Success("Automação alterada com sucesso!");

            return View("Detalhes");
        }

        private bool Validar(AutomacaoViewModel viewModel)
        {
            var validator = new AutomacaoViewModelValidator();

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
