using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses
{
    public class GetResponse<T> : BaseResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
        [JsonPropertyName("totalAmount")]
        public int TotalAmount { get; set; }
        [JsonPropertyName("result")]
        public IEnumerable<T> Result { get; set; }
    }
}
