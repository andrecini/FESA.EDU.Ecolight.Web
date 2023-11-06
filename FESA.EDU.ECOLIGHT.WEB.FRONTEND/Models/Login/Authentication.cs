using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login
{
    public class Authentication
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("token")]
        public TokenModel Token { get; set; }
    }
}
