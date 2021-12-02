using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo_list.api.Data.Interfaces;
using todo_list.api.Models;
using todo_list.api.Notifications;
using todo_list.api.Services.Interfaces;
using todo_list.api.Validations;

namespace todo_list.api.Services
{
    public class TodoService : ServiceBase, ITodoService
    {
        private readonly ITodoRepository _repository;
        public TodoService(ITodoRepository repository, INotifier notifier) : base(notifier)
        {
            _repository = repository;
        }
        public async Task<Todo> AddTodo(Todo todo)
        {
            if (!Validate(new TodoValidations(), todo)) return null;

            _repository.Add(todo);

            var result = await _repository.UnitOfWork.Commit();

            if (!result)
            {
                Notify("Error when creating the activity!");
                return null;
            }

            return todo;
        }

        public async Task RemoveTodo(Guid id)
        {
            var existingTodo = await _repository.GetById(id);

            if (existingTodo is null)
            {
                Notify("No activity found");
                return;
            }

            _repository.Remove(existingTodo);

            var result = await _repository.UnitOfWork.Commit();

            if (!result)
            {
                Notify("Error in activity exclusion");
            }
        }

        public async Task UpdateTodo(Todo todo)
        {
            if (!Validate(new TodoValidations(true), todo)) return;

            var existingTodo = await _repository.GetById(todo.Id);

            if (existingTodo is null)
            {
                Notify("No activity found");
                return;
            }

            existingTodo.ChangeTittle(todo.Title);
            existingTodo.ChangeActivityStatus(todo.Done);

            var result = await _repository.UnitOfWork.Commit();

            if (!result)
            {
                Notify("Error when updating the activity");
            }
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _repository.GetAll();
        }

        public async Task<Todo> GetTodoById(Guid id)
        {
           return await _repository.GetById(id);
        }
    }
}
