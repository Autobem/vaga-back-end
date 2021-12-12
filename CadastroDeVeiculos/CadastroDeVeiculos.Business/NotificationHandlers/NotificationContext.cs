using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeVeiculos.Business.NotificationHandlers
{
    public class NotificationContext : Interfaces.NotificationHandler.INotificationContext
    {
        private readonly List<DomainNotification> _notifications;

        public NotificationContext()
        {
            this._notifications = new List<DomainNotification>();
        }

        public bool HasNotifications() => this._notifications.Any();

        public List<DomainNotification> GetNotifications() => this._notifications;

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
