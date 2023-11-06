using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Helpers;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Dispositivo;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class DispositivosController : Controller
    {
        public INotyfService _notifyService { get; }
        public HttpClient _httpClient { get; }

        public DispositivosController(INotyfService notifyService, IHttpClientFactory factory)
        {
            _notifyService = notifyService;
            _httpClient = factory.CreateClient("MyClient");            
        }

        public async Task<IActionResult> Index()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var devices = await ApiHelper.SendGetRequest(_httpClient, "/v1/devices?companyId=1");

            var result = await devices.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetResponse<DispositivoViewModel>>(result);

            return View(response.Result);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar(DispositivoViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Cadastro");

            var devices = await ApiHelper.SendPostRequest<DispositivoViewModel>(_httpClient, "v1/devices", viewModel);

            _notifyService.Success("Dispositivo cadastrado com sucesso!");

            return View("Index");
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public async Task<IActionResult> Editar(DispositivoViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Detalhes");

            var devices = await ApiHelper.SendPostRequest<DispositivoViewModel>(_httpClient, $"v1/settings?id{viewModel.Id}", viewModel);

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
