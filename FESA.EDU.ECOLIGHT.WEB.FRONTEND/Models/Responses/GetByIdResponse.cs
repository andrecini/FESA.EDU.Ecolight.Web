namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses
{
    public class GetByIdResponse<T> : BaseResponse
    {
        public T Result { get; set; }
    }
}
