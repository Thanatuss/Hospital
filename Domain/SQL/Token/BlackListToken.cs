namespace Domain.SQL.Token
{
    public class BlackListToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
