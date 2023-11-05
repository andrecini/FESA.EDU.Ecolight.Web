﻿using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Responses
{
    public class BaseResponse
    {
        [JsonPropertyName("sucess")]
        public bool Success { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
