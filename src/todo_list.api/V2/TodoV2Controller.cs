using Microsoft.AspNetCore.Mvc;
using todo_list.api.Controllers;

namespace todo_list.api.V2
{
    public class TodoV2Controller : MainController
    {
        [ApiVersion("2.0")]
        [Route("api/v{version:apiVersion}/teste")]

        [HttpGet]
        public string Valor()
        {
            return "Versão 2";
        }
    }
}
