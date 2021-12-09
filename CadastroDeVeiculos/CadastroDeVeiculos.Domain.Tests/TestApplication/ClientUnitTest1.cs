using CadastroDeVeiculos.Domain.Entities;
using CadastroDeVeiculos.Domain.ValueObject;
using FluentAssertions;
using System;
using Xunit;

namespace CadastroDeVeiculos.Domain.Tests.TestApplication
{
    public class ClientUnitTest1
    {
        [Fact]
        public void Client_CriandoNovoObjeto_ValoresValidos()
        {
            Name name = new Name("Igor", "Silva");
            var client = new Client(name, "11910734678", "igorsevenn@gmail.com", "44233355522");
            Assert.True(client.Valid);
        }

        [Fact]
        public void CLient_SemSobrenome_ValoresInvalidos()
        {
            Name name = new Name("Igor", "");
            var client = new Client(name, "11910734678", "igorsevenn@gmail.com", "44233355522");
            Assert.True(client.Invalid);
        }

        [Fact]
        public void CLient_SemAlgunsNumerosDoTelefone_ValoresInvalidos()
        {
            Name name = new Name("Igor", "Silva");
            var client = new Client(name, "910734678", "igorsevenn@gmail.com", "44233355522");
            Assert.True(client.Invalid);
        }

        [Fact]
        public void CLient_SemAlgunsNumerosDoDocumento_ValoresInvalidos()
        {
            Name name = new Name("Igor", "Silva");
            var client = new Client(name, "11910734678", "igorsevenn@gmail.com", "442333555");
            Assert.True(client.Invalid);
        }

        [Fact]
        public void CLient_EmailIncorreto_ValoresInvalidos()
        {
            Name name = new Name("Igor", "Silva");
            var client = new Client(name, "11910734678", "igorsevenngmail.com", "44233355522");
            Assert.True(client.Invalid);
        }
    }
}
