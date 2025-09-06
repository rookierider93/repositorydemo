using MongoDB.Driver;
using todo.api.models;
using todo.api.services;

namespace todo.api.repositories
{
    public class userRepository:TodoRepository<user>
    {
        public userRepository(TodoService context):base(context,"users")
        {
        }

        public async Task<user?> GetByNameAsync(string name)
        {
            return await _collection.Find(Builders<user>.Filter.Eq("UserName", name)).FirstOrDefaultAsync();
        }
    }
}
