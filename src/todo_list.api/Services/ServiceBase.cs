using FluentValidation;
using FluentValidation.Results;
using todo_list.api.Models;
using todo_list.api.Notifications;
using todo_list.api.Services.Interfaces;

namespace todo_list.api.Services
{
    public abstract class ServiceBase
    {
        private readonly INotifier _notifier;
        public ServiceBase(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool Validate<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
