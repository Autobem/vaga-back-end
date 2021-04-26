namespace BuildingBlocks.Domain.Generics.CPF
{
    public struct CPF
    {
        public string Value => this._value;

        private readonly string _value;

        private CPF(string value) { _value = value; }

        public static CPF Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }
            throw new InvalidCPFException();
        }

        public static bool TryParse(string value, out CPF cpf)
        {
            if (!IsCpf(value))
            {
                cpf = default;
                return false;
            }

            cpf = new CPF(value);
            return true;
        }

        public static bool IsCpf(string cpf)
        {
            if (cpf == null)
            {
                return false;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static implicit operator CPF(string value)
          => Parse(value);
    }
}
