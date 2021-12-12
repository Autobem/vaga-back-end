using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroDeVeiculos.Api.Filters
{
    public class ErrorFilterAttribute : ActionFilterAttribute
    {
        private readonly INotificationContext notification;

        public ErrorFilterAttribute(INotificationContext notification)
        {
            this.notification = notification;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (this.notification.HasNotifications())
            {
                context.Result = new BadRequestObjectResult(this.notification.GetNotifications());
            }

            base.OnActionExecuted(context);
        }
    }
}
