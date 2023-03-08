namespace ReactAndAspNetTutorial.Auth
{
    public class JwtToken
    {
        public string Value { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
    }
}
