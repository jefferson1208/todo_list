using Microsoft.AspNetCore.Mvc;
using todo_list.api.Controllers;
using todo_list.api.Notifications;

namespace todo_list.api.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/todo")]
    public class TodoV2Controller : MainController
    {
        public TodoV2Controller(INotifier notifier) : base(notifier)
        {

        }

        [HttpGet("test")]
        public string Version_Two()
        {
            return "Version 2";
        }
    }
}
