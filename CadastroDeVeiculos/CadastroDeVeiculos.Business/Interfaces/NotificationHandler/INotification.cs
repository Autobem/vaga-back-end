using CadastroDeVeiculos.Business.NotificationHandlers;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CadastroDeVeiculos.Business.Interfaces.NotificationHandler
{
    public interface INotification
    {
        bool HasNotification();
        void AddNotification(string key, string value);
        void AddNotification(DomainNotification notification);
        void AddNotifications(IEnumerable<DomainNotification> notifications);
        void AddNotifications(ValidationResult validationResult);
    }
}
