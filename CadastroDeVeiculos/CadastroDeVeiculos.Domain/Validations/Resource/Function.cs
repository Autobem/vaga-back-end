namespace CadastroDeVeiculos.Domain.Validations.Resource
{
    public static class Function
    {

        public static string FormatMessage(this string message, params object[] args)
        {
            return string.Format(message, args);
        }
    }
}
