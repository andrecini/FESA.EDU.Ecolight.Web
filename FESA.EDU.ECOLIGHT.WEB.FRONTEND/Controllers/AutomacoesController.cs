using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Helpers;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Dispositivo;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
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
        }

        public async Task<IActionResult> Index()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var automacoes = await ApiHelper.SendGetRequest(_httpClient, "v1/settings?page=1&pageSize=5");

            var result = await automacoes.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetResponse<AutomacaoViewModel>>(result);

            return View(response.Result);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar(AutomacaoViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Cadastro");

            var settings = await ApiHelper.SendPostRequest<AutomacaoViewModel>(_httpClient, "v1/settings", viewModel);

            _notifyService.Success("Automação cadastrada com sucesso!");

            return View("Index");
        }

        public async Task<IActionResult> Detalhes()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var automacoes = await ApiHelper.SendGetRequest(_httpClient, "/v1/settings/1");

            var result = await automacoes.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetByIdResponse<AutomacaoViewModel>>(result);

            return View(response.Result);
        }

        public async Task<IActionResult> Editar(AutomacaoViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Detalhes");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var settings = await ApiHelper.SendPutRequest<AutomacaoViewModel>(_httpClient, $"v1/settings?id={viewModel.Id}", viewModel);

            _notifyService.Success("Automação alterada com sucesso!");

            return RedirectToAction("Detalhes");
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
