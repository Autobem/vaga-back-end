namespace DevAssuncaoCarros.API.Configurations
{
    public class JsonWebToken
    {
        public string Secret { get; set; }
        public string ValidoEm { get; set; }
        public string Emissor { get; set; }
        public int Expiracao { get; set; }
    }
}