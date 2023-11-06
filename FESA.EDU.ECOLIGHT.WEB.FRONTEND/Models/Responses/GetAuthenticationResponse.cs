using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses
{
    public class GetAuthenticationResponse<T> : BaseResponse
    {
        [JsonPropertyName("auth")]
        public T Auth { get; set; }
    }
}
