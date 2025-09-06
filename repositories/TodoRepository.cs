
using MongoDB.Driver;
using todo.api.services;

namespace todo.api.repositories
{
    public class TodoRepository<T> : ITodoRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        public TodoRepository(TodoService context, string collectionName)
        {
            _collection = context.GetCollection<T>(collectionName);
        }
        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
             await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);
        }
    }
}
