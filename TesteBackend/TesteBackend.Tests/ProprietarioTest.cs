using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Core.Interfaces.Services;
using Teste.Domain.Entities;
using Xunit;

namespace TesteBackend.Tests
{
    public class ProprietarioTest
    {
        private readonly IProprietarioService

        [Fact]
        public void AdicionarProprietario()
        {
            var proprietario = new Proprietario();
            proprietario.NomeCompleto = "Karen Garbim";
            proprietario.DataNascimento = DateTime.Parse("1992-06-20");
            proprietario.Cpf = "11112213314";
            
        }
    }
}
