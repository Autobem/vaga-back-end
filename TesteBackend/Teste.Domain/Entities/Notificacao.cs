using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Domain.Entities
{
    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }
    }
}
