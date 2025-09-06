using Microsoft.Extensions.Options;
using MongoDB.Driver;
using todo.api.models;

namespace todo.api.services
{
    public class TodoService
    {
        private readonly IMongoDatabase _database;
        public TodoService(IOptions<TodoDatabaseSettings> options)
        {
            var mongoClient=new MongoClient(
                options.Value.ConnectionString);

            _database=mongoClient.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)=>
            _database.GetCollection<T>(name);

    }
}
