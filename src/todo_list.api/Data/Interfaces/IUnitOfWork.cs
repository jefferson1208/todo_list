using System.Threading.Tasks;

namespace todo_list.api.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
