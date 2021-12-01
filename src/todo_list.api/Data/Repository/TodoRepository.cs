using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo_list.api.Data.Context;
using todo_list.api.Data.Interfaces;
using todo_list.api.Models;

namespace todo_list.api.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly TodoContext _context;
        public TodoRepository(TodoContext context)
        {
            _context = context;
        }
        public void Add(Todo entity)
        {
            _context.TodoList.Add(entity);
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            await Task.CompletedTask;
            return _context.TodoList;
        }

        public async Task<Todo> GetById(Guid id)
        {
            await Task.CompletedTask;

            return _context.TodoList.Find(t => t.Id == id);
        }

        public void Remove(Todo entity)
        {
            _context.TodoList.Remove(entity);
        }

    }
}
