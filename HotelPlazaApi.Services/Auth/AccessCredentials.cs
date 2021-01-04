namespace FrequenciaApi.Services.Auth
{
    public class AccessCredentials
    {
        public string UserID { get; set; }
        public int Matricula { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }
}
