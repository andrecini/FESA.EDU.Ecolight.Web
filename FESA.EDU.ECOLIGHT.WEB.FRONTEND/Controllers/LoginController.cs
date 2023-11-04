using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class LoginController : Controller
    {
        private readonly INotyfService _notifyService;

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
            HttpContext.Session.SetString("role", "admin");
            HttpContext.Session.SetString("username", "André Cini");

            _notifyService.Success("Bem vindo ao nosso sistema!");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Cadastrar(LoginViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Cadastro");

            _notifyService.Success("Usuário Cadastrado com sucesso!");

           return View("Index");
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
        private bool Validar(LoginViewModel viewModel)
        {
            var validator = new LoginViewModelValidator();

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
