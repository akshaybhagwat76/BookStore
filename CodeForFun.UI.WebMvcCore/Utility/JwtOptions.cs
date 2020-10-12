namespace CodeForFun.UI.WebMvcCore.Utility
{
    public class JwtOptions
    {
        public string Token { get; set; }
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
