using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NetCoreWebApiTest.DOTs
{
    public class GetAllCharacterNameResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
