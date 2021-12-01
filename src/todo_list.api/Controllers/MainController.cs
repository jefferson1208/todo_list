using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using todo_list.api.Models;
using todo_list.api.Notifications;

namespace todo_list.api.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        private readonly INotifier _notifier;
        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }
        protected bool CheckOperation()
        {
            return !_notifier.CheckNotifications();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (CheckOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModel(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

                NotifyError(errorMessage);
            }
        }

        protected void NotifyError(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
