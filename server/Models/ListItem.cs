using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    [BsonIgnoreExtraElements] // ignores if there are fields in MongoDB which is not present here
    public class ListItem
    {
        [BsonId] // maps ID in mongoDB to ListElement Id
        [BsonRepresentation(BsonType.ObjectId)] // Converts mongodata to a .net data type (and vica verca)
        public string Id { get; set; } = string.Empty;
        
        [BsonElement("name")] // maps to mongoDB property (casing is different)
        public string Name { get; set; } = string.Empty;

        [BsonElement("isComplete")]
        public bool IsComplete { get; set; }
    }
}
