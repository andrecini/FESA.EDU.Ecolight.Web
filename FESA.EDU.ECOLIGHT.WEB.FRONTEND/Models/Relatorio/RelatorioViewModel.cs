using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Dispositivo;
using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Relatorio
{
    public class RelatorioViewModel
    {
        [JsonPropertyName("carbonEmission")]
        public float EmissaoDeCarbono { get; set; }

        [JsonPropertyName("devicesExpenses")]
        public float CustoDispositivos { get; set; }

        [JsonPropertyName("criticalDevices")]
        public IEnumerable<DispositivoViewModel> DispositivosCriticos { get; set; }

        [JsonPropertyName("allDevices")]
        public IEnumerable<DispositivoViewModel> TodosDispositivos { get; set; }

        [JsonPropertyName("monthlyKwhSavings")]
        public IEnumerable<float> EconomiaMensalKwh { get; set; }

        [JsonPropertyName("monthlyDevicesExpenseSavings")]
        public IEnumerable<float> EconomiaMensalCustos { get; set; }

    }
}
