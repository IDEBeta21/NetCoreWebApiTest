using MongoDB.Driver;
using NetCoreWebApiTest.DOTs;

namespace NetCoreWebApiTest.Services
{
    public class CharacterServices : ICharacterServices
    {
        public List<GetCharacterResponse> GetAllCharacters()
        {
            string connString = "mongodb://localhost:27017";
            string dbName = "dotnet-rpg";
            string collectionName = "characters";

            var client = new MongoClient(connString);
            var db = client.GetDatabase(dbName);
            var collection = db.GetCollection<GetCharacterResponse>(collectionName);

            var results = collection.Find(_ => true);

            //throw new NotImplementedException();
            List<GetCharacterResponse> response = new List<GetCharacterResponse>();

            foreach( var result in results.ToList())
            {
                response.Add(new GetCharacterResponse()
                {
                    Id = result.Id,
                    Name = result.Name,
                    HitPoints = result.HitPoints,
                    Strength = result.Strength,
                    Defense = result.Defense,
                    Intelligence = result.Intelligence,
                    Class = result.Class
                }); ;
            }

            return response;
        }
    }
}
