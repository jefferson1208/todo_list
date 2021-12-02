using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using todo_list.api.Controllers;
using todo_list.api.Models;
using todo_list.api.Notifications;
using todo_list.api.Services.Interfaces;
using todo_list.api.VeiwModels;

namespace todo_list.api.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/todo")]

    public class TodoController : MainController
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;
        public TodoController(ITodoService todoService, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTodo([FromBody] TodoViewModel todo)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = _mapper.Map<TodoBaseViewModel>(await _todoService.AddTodo(_mapper.Map<Todo>(todo)));

            return CustomResponse(result);

        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveTodo([FromQuery] string id)
        {
            await _todoService.RemoveTodo(Guid.Parse(id));
            
            return CustomResponse();

        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateTodo([FromBody] TodoBaseViewModel todo)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _todoService.UpdateTodo(_mapper.Map<Todo>(todo));

            return CustomResponse(todo);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> GetTodos()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var todos = await _todoService.GetAllTodos();

            return CustomResponse(todos);

        }

        [HttpGet("todo-by-id")]
        public async Task<IActionResult> GetTodoById([FromQuery] string id)
        {
            var todo = await _todoService.GetTodoById(Guid.Parse(id));

            return CustomResponse(todo);

        }
    }
}
