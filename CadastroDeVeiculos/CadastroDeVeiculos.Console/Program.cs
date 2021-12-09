using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.ValueObject;
using System;
using System.Linq;

namespace CadastroDeVeiculos.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Name name = new Name("Igor", "Silva");
            var client = new Client(name, "11910734678", "igorsevenn@gmail.com", "44233355522");

            client.ValidationResult.Errors.ToList().ForEach(e =>
            {
                Console.WriteLine(e.ErrorMessage);
            });
        }
    }
}
