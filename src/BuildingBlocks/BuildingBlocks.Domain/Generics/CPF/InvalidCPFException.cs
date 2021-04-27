using System;

namespace BuildingBlocks.Domain.Generics.CPF
{
    public class InvalidCPFException : Exception
    {
        public InvalidCPFException(string cpf) : base($"CPF {cpf} é inválido.")
        {
        }
    }
}
