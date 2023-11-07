using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Helpers;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Dispositivo;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class LoginController : Controller
    {
        private readonly INotyfService _notifyService;
        public HttpClient _httpClient { get; }

        public LoginController(INotyfService notifyService, IHttpClientFactory factory)
        {
            _notifyService = notifyService;
            _httpClient = factory.CreateClient("MyClient");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Acessar(string email, string senha)
        {

            var user = await ApiHelper.SendGetRequest(_httpClient, $"v1/authentications/login?email={email}&password={senha}");

            var result = await user.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetAuthenticationResponse<Authentication>>(result);

            if (!response.Success)
            {
                _notifyService.Warning("Email ou Senha incorretos!");
                return View("Index");
            }

            //HttpContext.Session.SetString("role", "admin");
            HttpContext.Session.SetString("username", response.Auth.UserName);
            HttpContext.Session.SetString("token", response.Auth.Token.Token);
            HttpContext.Session.SetString("empresa", response.Auth.EmpresaId.ToString());

            _notifyService.Success("Bem vindo ao nosso sistema!");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar(LoginViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Cadastro");

            _notifyService.Success("Usuário Cadastrado com sucesso!");

            var user = await ApiHelper.SendPostRequest<LoginViewModel>(_httpClient, "v1/users", viewModel);

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
