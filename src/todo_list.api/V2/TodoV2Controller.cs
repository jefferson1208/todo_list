using Microsoft.AspNetCore.Mvc;
using todo_list.api.Controllers;
using todo_list.api.Notifications;

namespace todo_list.api.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TodoV2Controller : MainController
    {
        public TodoV2Controller(INotifier notifier) : base(notifier)
        {

        }

        [HttpGet]
        public string Valor()
        {
            return "Versão 2";
        }
    }
}
