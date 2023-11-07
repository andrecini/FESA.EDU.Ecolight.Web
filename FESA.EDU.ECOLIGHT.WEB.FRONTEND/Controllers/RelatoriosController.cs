using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Helpers;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Home;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Relatorio;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class RelatoriosController : Controller
    {
        public INotyfService _notifyService { get; }
        public HttpClient _httpClient { get; }

        public RelatoriosController(INotyfService notifyService, IHttpClientFactory factory)
        {
            _notifyService = notifyService;
            _httpClient = factory.CreateClient("MyClient");
        }

        public async Task<IActionResult> Index()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var automacoes = await ApiHelper.SendGetRequest(_httpClient, $"/v1/dashboards/report?companyId={HttpContext.Session.GetString("empresa")}");

            var result = await automacoes.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<GetByIdResponse<RelatorioViewModel>>(result);

            var viewModel = response.Result;

            return View(viewModel);
        }
    }
}
