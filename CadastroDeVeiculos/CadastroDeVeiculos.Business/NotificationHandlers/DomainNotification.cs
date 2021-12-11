namespace CadastroDeVeiculos.Business.NotificationHandlers
{
    public class DomainNotification
    {
        public string Key { get; private set; }
        public string Value { get; private set; }


        public DomainNotification(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

    }
}
