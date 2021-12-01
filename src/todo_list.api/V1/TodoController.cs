using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using todo_list.api.Controllers;

namespace todo_list.api.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/todo")]
    public class TodoController : MainController
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer()
        {
            await Task.CompletedTask;

            return Ok("Feito");

        }
    }
}
