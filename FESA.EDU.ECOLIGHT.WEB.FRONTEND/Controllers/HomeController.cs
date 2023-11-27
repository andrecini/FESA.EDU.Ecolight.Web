using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.Ecolight.Web.FRONTEND.Models;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Helpers;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Home;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public INotyfService _notifyService { get; }
        public HttpClient _httpClient { get; }

        public HomeController(ILogger<HomeController> logger, INotyfService notifyService, IHttpClientFactory factory)
        {
            _logger = logger;
            _notifyService= notifyService;
            _httpClient = factory.CreateClient("MyClient");
        }

        public async Task<IActionResult> Index()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var automacoes = await ApiHelper.SendGetRequest(_httpClient, "/v1/dashboards?companyId=1");

            var result = await automacoes.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetByIdResponse<HomeViewModel>>(result);

            var viewModel = response.Result;
            viewModel.Rotinas = await GetRotinas();

            return View(response.Result);
        }

        private async Task<IEnumerable<AutomacaoViewModel>> GetRotinas()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var automacoes = await ApiHelper.SendGetRequest(_httpClient, "v1/settings?companyId=1");

            var result = await automacoes.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetResponse<AutomacaoViewModel>>(result);

            return response.Result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
