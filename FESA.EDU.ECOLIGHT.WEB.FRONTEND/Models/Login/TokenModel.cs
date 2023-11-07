using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login
{
    public class TokenModel
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
        [JsonPropertyName("validTo")]
        public DateTime ValidTo { get; set; }
    }
}
