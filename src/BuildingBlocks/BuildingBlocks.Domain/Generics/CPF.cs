using System;

namespace BuildingBlocks.Domain.Generics
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
            throw new ArgumentException("CPF inválido.");
        }

        public static bool TryParse(string value, out CPF cpf)
        {
            //.. validation Logic 
            cpf = new CPF(value);

            return true;
        }


        public static implicit operator CPF(string value)
          => Parse(value);
    }
}
