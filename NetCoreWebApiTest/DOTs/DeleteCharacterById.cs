using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using NetCoreWebApiTest.Model;

namespace NetCoreWebApiTest.DOTs
{
    public class DeleteCharacterByIdRequest
    {
        public string Id { get; set; }
    }

    public class DeleteCharacterByIdResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RPGClass Class { get; set; } = RPGClass.Knight;
    }
}
