using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todo.api.models
{
    public class user
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("name")]
        public string UserName { get; set; }

    }
}
