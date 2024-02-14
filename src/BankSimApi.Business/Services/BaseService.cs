using BankSimApi.Business.Interfaces;
using BankSimApi.Business.Models;
using BankSimApi.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace BankSimApi.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;
        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificate(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notificate(item.ErrorMessage);
            }
        }

        protected void Notificate(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected bool Validate<TV, TE> (TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;
            return false;
        }
    }
}
