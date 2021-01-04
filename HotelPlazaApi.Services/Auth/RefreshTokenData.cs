using System;

namespace FrequenciaApi.Services.Auth
{
    public class RefreshTokenData
    {
        public string RefreshToken { get; set; }
        public int UserID { get; set; }
        public DateTime FinalExpiration { get; set; }
    }
}
