using FluentValidation;
using System;
using todo_list.api.Models;

namespace todo_list.api.Validations
{
    public class TodoValidations : AbstractValidator<Todo>
    {
        public TodoValidations(bool update = false)
        {
            if (update)
            {
                RuleFor(t => t.Id).
                    NotNull().WithMessage("The {PropertyName} Field is required!")
                    .NotEmpty().WithMessage("The {PropertyName} Field is required!")
                    .NotEqual(Guid.Empty).WithMessage("The {PropertyName} Field must be a valid Guid!");
            }

            RuleFor(t => t.Title)
                .NotNull().WithMessage("The {PropertyName} Field is required!")
                .NotEmpty().WithMessage("The {PropertyName} Field is required!")
                .MinimumLength(10).WithMessage("The {PropertyName} Field must be at least 10 characters long!")
                .MaximumLength(50).WithMessage("The {PropertyName} field must have a maximum of 50 characters!");

        }
    }
}
