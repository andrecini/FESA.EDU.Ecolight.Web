using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses
{
    public class GetByIdResponse<T> : BaseResponse
    {
        [JsonPropertyName("result")]
        public T Result { get; set; }
    }
}
