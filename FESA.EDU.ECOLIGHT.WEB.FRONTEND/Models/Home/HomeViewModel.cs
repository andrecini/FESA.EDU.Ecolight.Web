using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Home
{

    public class HomeViewModel
    {
        [JsonPropertyName ("active")]
        public int Ativo { get; set; }

        [JsonPropertyName("inactive")]
        public int Inativo { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("monthlyKwhUsage")]
        public IEnumerable<float> UsoKwhMensal { get; set; }

        [JsonPropertyName("monthlyDeviceExpenses")]
        public IEnumerable<float> DespesasDispositivosMensal { get; set; }
    }
}
