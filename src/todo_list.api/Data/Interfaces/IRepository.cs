using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo_list.api.Models;

namespace todo_list.api.Data.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(T entity);
        void Remove(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
