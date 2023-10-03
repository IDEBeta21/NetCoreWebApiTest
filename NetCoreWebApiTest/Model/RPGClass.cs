using System.Text.Json.Serialization;

namespace NetCoreWebApiTest.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RPGClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }
}
