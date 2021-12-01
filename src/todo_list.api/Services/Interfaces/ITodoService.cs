using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo_list.api.Models;

namespace todo_list.api.Services.Interfaces
{
    public interface ITodoService
    {
        Task<Todo> AddTodo(Todo todo);
        Task RemoveTodo(Guid id);
        Task UpdateTodo(Todo todo);
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodoById(Guid id);
    }
}
