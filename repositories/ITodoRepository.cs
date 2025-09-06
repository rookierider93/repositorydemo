using todo.api.services;

namespace todo.api.repositories
{
    public interface ITodoRepository<T> 
    {

        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task RemoveAsync(string id);
    }
}
 