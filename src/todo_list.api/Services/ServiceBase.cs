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

        protected void Notify(ValidationResult validationResult, int codError)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage, codError);
            }
        }

        protected void Notify(string mensagem, int codError)
        {
            _notifier.Handle(new Notification(mensagem, codError));
        }

        protected bool Validate<TV, TE>(TV validation, TE entity, int codError) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator, codError);

            return false;
        }
    }
}
