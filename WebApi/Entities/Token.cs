namespace WebApi.Entities
{
    public class Token
    {
        public string AccessToken    { get; set; }
        public DateTime Experation { get; set; }
        public string RefreshToken { get; set; }

    }
}