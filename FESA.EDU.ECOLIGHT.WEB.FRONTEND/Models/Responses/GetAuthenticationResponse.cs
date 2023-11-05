namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses
{
    public class GetAuthenticationResponse<T> : BaseResponse
    {
        public T Auth { get; set; }
    }
}
