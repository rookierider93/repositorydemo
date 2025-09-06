using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todo.api.models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string TaskName { get; set; }
        public string UserName { get; set; }

    }
}
