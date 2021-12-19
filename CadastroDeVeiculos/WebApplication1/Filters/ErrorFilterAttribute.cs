using CadastroDeVeiculos.Business.Interfaces.NotificationHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroDeVeiculos.WebApi.Filters
{
    public class ErrorFilterAttribute : ActionFilterAttribute
    {
        private readonly INotificationContext _notification;

        public ErrorFilterAttribute(INotificationContext notification)
        {
            this._notification = notification;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (this._notification.HasNotifications())
            {
                context.Result = new BadRequestObjectResult(this._notification.GetNotifications());
            }

            base.OnActionExecuted(context);
        }
    }
}
