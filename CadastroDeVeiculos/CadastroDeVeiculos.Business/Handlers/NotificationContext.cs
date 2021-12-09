using CadastroDeVeiculos.Business.Interfaces.Handler;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeVeiculos.Business.Handlers
{
    public class NotificationContext : INotification
    {
        private readonly List<DomainNotification> _notifications;

        public NotificationContext()
        {
            this._notifications = new List<DomainNotification>();
        }

        public bool HasNotification() => this._notifications.Any();

        public void AddNotification(string key, string value)
        {
            this._notifications.Add(new DomainNotification(key, value));
        }

        public void AddNotification(DomainNotification notification)
        {
            this._notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<DomainNotification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                this._notifications.Add(new DomainNotification(erro.ErrorCode, erro.ErrorMessage));
            }
        }
    }
}
