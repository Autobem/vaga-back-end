using System;

namespace BuildingBlocks.Domain.Generics.CPF
{
    public class InvalidCPFException : Exception
    {
        public InvalidCPFException() : base("CPF inválido.")
        {
        }
    }
}
