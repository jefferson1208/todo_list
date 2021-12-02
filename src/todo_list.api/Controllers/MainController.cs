using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Net;
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

            return GenerateActionResult(_notifier.GetNotifications().Select(n => n.CodeError).FirstOrDefault());
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState, int codError)
        {
            if (!modelState.IsValid) NotifyInvalidModel(modelState, codError);
            return CustomResponse();
        }

        protected void NotifyInvalidModel(ModelStateDictionary modelState, int codError)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

                NotifyError(errorMessage, codError);
            }
        }

        protected void NotifyError(string message, int codError)
        {
            _notifier.Handle(new Notification(message, codError));
        }

        private ActionResult GenerateActionResult(int statusCode)
        {
            ActionResult actionResult;

            switch ((HttpStatusCode)statusCode)
            {
                case HttpStatusCode.NotFound:
                    actionResult = NotFound(new
                    {
                        success = false,
                        errors = _notifier.GetNotifications().Select(n => n.Message)
                    });
                    break;
               
                default:
                    actionResult = BadRequest(new
                    {
                        success = false,
                        errors = _notifier.GetNotifications().Select(n => n.Message)
                    });
                    break;
            }

            return actionResult;
        }
    }
}
