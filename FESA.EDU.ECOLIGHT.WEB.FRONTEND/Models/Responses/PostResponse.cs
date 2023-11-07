namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses
{
    public class PostResponse<T> : BaseResponse
    {
        public string URI { get; set; }
        public T CreatedEntity { get; set; }
    }
}
