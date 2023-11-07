using AspNetCoreHero.ToastNotification.Abstractions;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Helpers;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Home;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses;
using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FESA.EDU.Ecolight.Web.FRONTEND.Controllers
{
    public class UsuariosController : Controller
    {
        public INotyfService _notifyService { get; }
        public HttpClient _httpClient { get; }

        public UsuariosController(INotyfService notifyService, IHttpClientFactory factory)
        {
            _notifyService = notifyService;
            _httpClient = factory.CreateClient("MyClient");
        }

        public async Task<IActionResult> Index()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var userId = Convert.ToInt32(HttpContext.Session.GetString("userid"));

            var result = await ApiHelper.SendGetRequest(_httpClient, $"/v1/users/{userId}");

            var content = await result.Content.ReadAsStringAsync();

            var dadosUsuario = JsonSerializer.Deserialize<GetByIdResponse<UsuariosViewModel>>(content);

            return View(dadosUsuario.Result);
        }

        public async Task<IActionResult> Editar(UsuariosViewModel viewModel)
        {
            if (!Validar(viewModel))
                return View("Index");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var result = await ApiHelper.SendPutRequest(_httpClient, $"/v1/users?id={viewModel.Id}", viewModel);

            var content = await result.Content.ReadAsStringAsync();

            var dadosUsuario = JsonSerializer.Deserialize<GetByIdResponse<UsuariosViewModel>>(content);

            if (!dadosUsuario.Success)
            {
                _notifyService.Success("Não foi possível alterar os Dados do Usuário!");

                return RedirectToAction("Index");
            }

            _notifyService.Success("Dados do Usuário alterados com sucesso!");

            return RedirectToAction("Index");
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
