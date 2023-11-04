using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Usuarios;
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
            if (!Validar(viewModel))
                return View("Index");

            _notifyService.Success("Dados do Usuário alterados com sucesso!");

            return View("Index");
        }

        private bool Validar(UsuariosViewModel viewModel)
        {
            var validator = new UsuariosViewModelValidator();

            var results = validator.Validate(viewModel);

            if (results.IsValid)            
                return true;            

            var erros = results.Errors;

            foreach (var erro in erros)
            {
                _notifyService.Warning(erro.ErrorMessage);
            }

            return false;
        }
    }
}
