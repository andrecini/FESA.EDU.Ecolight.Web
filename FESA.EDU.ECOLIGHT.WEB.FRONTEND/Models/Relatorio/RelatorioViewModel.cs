using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Dispositivo;
using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Relatorio
{
    public class RelatorioViewModel
    {
        [JsonPropertyName("carbonEmission")]
        public float EmissaoDeCarbono { get; set; }

        [JsonPropertyName("DevicesExpenses")]
        public float CustoDispositivos { get; set; }

        [JsonPropertyName("CriticalDevices")]
        public IEnumerable<DispositivoViewModel> DispositivosCriticos { get; set; }

        [JsonPropertyName("AllDevices")]
        public IEnumerable<DispositivoViewModel> TodosDispositivos { get; set; }

        [JsonPropertyName("MonthlyKwhSavings")]
        public IEnumerable<float> EconomiaMensalKwh { get; set; }

        [JsonPropertyName("MonthlyDevicesExpenseSavings")]
        public IEnumerable<float> EconomiaMensalCustos { get; set; }

    }
}
