using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Helpers;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class AutomacoesController : Controller
    {
        public INotyfService _notifyService { get; }
        public HttpClient _httpClient { get; }

        public AutomacoesController(INotyfService notifyService, IHttpClientFactory factory)
        {
            _notifyService = notifyService;
            _httpClient = factory.CreateClient("MyClient");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2OTkyMjQ0MTIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.lRTmWTr_w0esDDh4qlrBTUjm7HUQBWtRbmDrSTK-_JI");
        }

        public async Task<IActionResult> Index()
        {
            var automacoes = await ApiHelper.SendGetRequest(_httpClient, "v1/settings?page=1&pageSize=5");

            var result = automacoes.Content.ReadAsStringAsync();

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
