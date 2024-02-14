using BankSimApi.Business.Interfaces;
using BankSimApi.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace BankSimApi.Api.Controllers
{
    public abstract class MainController : ControllerBase
    {
        private readonly INotificator _notificator;

        protected MainController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool ValidOperation()
        {
            return !_notificator.HasNotification();
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
        {
            if (ValidOperation())
            {
                return new ObjectResult(result)
                {
                    StatusCode = Convert.ToInt32(statusCode),
                };
            }

            return BadRequest(new
            {
                errors = _notificator.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificateError(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotificateError(errorMsg);
            }
        }
    }
}
