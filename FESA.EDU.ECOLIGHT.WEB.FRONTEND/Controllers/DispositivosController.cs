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

            var devices = await ApiHelper.SendGetRequest(_httpClient, $"/v1/devices?companyId={HttpContext.Session.GetString("empresa")}");

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

            viewModel.Ativo = viewModel.CheckAtivo ? "Active" : "Inactive";
            viewModel.EmpresaId = Convert.ToInt32(HttpContext.Session.GetString("empresa"));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var result = await ApiHelper.SendPostRequest(_httpClient, "v1/devices", viewModel);

            var json = await result.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetByIdResponse<DispositivoViewModel>>(json);

            if (!response.Success)
            {
                _notifyService.Warning("Não foi possível cadastrar o Dispositivo!");

                return View("Cadastro");
            }

            _notifyService.Success("Dispositivo cadastrado com sucesso!");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhes()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var device = await ApiHelper.SendGetRequest(_httpClient, $"/v1/devices/{HttpContext.Session.GetString("empresa")}");

            var result = await device.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetByIdResponse<DispositivoViewModel>>(result);

            return View(response.Result);
        }

        public async Task<IActionResult> Editar(DispositivoViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Detalhes");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            viewModel.Ativo = viewModel.CheckAtivo ? "Active" : "Inactive";
            viewModel.EmpresaId = Convert.ToInt32(HttpContext.Session.GetString("empresa"));

            var devices = await ApiHelper.SendPutRequest(_httpClient, "/v1/devices?id=1", viewModel);

            var result = await devices.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetResponse<DispositivoViewModel>>(result);

            if (!response.Success)
            {
                _notifyService.Warning("Não foi possível alterar o Dispositivo!");

                return View("Detalhes", viewModel);
            }

            _notifyService.Success("Dispositivo alterado com sucesso!");

            return RedirectToAction("Index");
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
