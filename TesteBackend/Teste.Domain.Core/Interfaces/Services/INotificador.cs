using System.Collections.Generic;
using Teste.Domain.Entities;

namespace Teste.Domain.Core.Interfaces.Services
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
