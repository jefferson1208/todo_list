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
            if (!Validate(new TodoValidations(), todo, 400)) return null;

            _repository.Add(todo);

            var result = await _repository.UnitOfWork.Commit();

            if (!result)
            {
                Notify("Error when creating the activity!", 400);
                return null;
            }

            return todo;
        }

        public async Task RemoveTodo(Guid id)
        {
            var existingTodo = await _repository.GetById(id);

            if (existingTodo is null || !existingTodo.Active)
            {
                Notify("No activity found", 404);
                return;
            }

            //remoção conceitual apenas
            existingTodo.DisableActivity();

            var result = await _repository.UnitOfWork.Commit();

            if (!result)
            {
                Notify("Error in activity exclusion", 400);
            }
        }

        public async Task UpdateTodo(Todo todo)
        {
            if (!Validate(new TodoValidations(true), todo, 400)) return;

            var existingTodo = await _repository.GetById(todo.Id);

            if (existingTodo.Title == todo.Title && existingTodo.Done == todo.Done) return;

            if (existingTodo is null)
            {
                Notify("No activity found", 404);
                return;
            }

            //aqui o ideal seria ter uma chamada para alterar cada informação
            existingTodo.ChangeTittle(todo.Title);
            existingTodo.ChangeActivityStatus(todo.Done);

            var result = await _repository.UnitOfWork.Commit();

            if (!result)
            {
                Notify("Error when updating the activity", 400);
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
