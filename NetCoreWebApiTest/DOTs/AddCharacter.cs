using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using NetCoreWebApiTest.Model;

namespace NetCoreWebApiTest.DOTs
{
    public class AddCharacterRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RPGClass Class { get; set; }
    }
}
