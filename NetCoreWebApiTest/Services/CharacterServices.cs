using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NetCoreWebApiTest.DOTs;

namespace NetCoreWebApiTest.Services
{
    public class CharacterServices : ICharacterServices
    {
        private readonly IConfiguration _configuration;
        private readonly string? _conString;
        private readonly string? _dbName;
        private readonly string? _characterCollectionName;
        public CharacterServices()
        {
            this._conString = "mongodb://localhost:27017";
            this._dbName = "dotnet-rpg";
            this._characterCollectionName = "characters";
        }

        public List<GetCharacterResponse> GetAllCharacters()
        {
            var client = new MongoClient(_conString);
            var db = client.GetDatabase(_dbName);
            var collection = db.GetCollection<GetCharacterResponse>(_characterCollectionName);

            var results = collection.Find(_ => true);

            //throw new NotImplementedException();
            List<GetCharacterResponse> response = new List<GetCharacterResponse>();

            //for debugging
            var resList = results.ToList();

            foreach( var result in resList)
            {
                response.Add(new GetCharacterResponse()
                {
                    Id = result.Id.ToString(),
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
        public List<AddCharacterResponse> AddCharacter(AddCharacterRequest request)
        {
            var client = new MongoClient(_conString);
            var db = client.GetDatabase(_dbName);
            var AddCharacterCollection = db.GetCollection<AddCharacterRequest>(_characterCollectionName);

            //Add new Character
            AddCharacterCollection.InsertOne(request);

            //Return Character
            var GetCharacterCollection = db.GetCollection<AddCharacterResponse>(_characterCollectionName);
            var results = GetCharacterCollection.Find(_ => true);
            List<AddCharacterResponse> response = new List<AddCharacterResponse>();

            //for debugging
            var resList = results.ToList();

            foreach (var result in resList)
            {
                response.Add(new AddCharacterResponse()
                {
                    Id = result.Id.ToString(),
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

        public GetSingleCharacterResponse GetSingleCharacterById(GetSingleCharacterRequest request)
        {
            var response = new GetSingleCharacterResponse();

            var client = new MongoClient(_conString);
            var db = client.GetDatabase(_dbName);
            var collection = db.GetCollection<GetSingleCharacterResponse>(_characterCollectionName);

            var objectIdToFind = new ObjectId(request.Id);
            var filter = Builders<GetSingleCharacterResponse>.Filter.Eq("_id", objectIdToFind);

            var result = collection.Find(filter).SingleOrDefault();

            response.Id = result.Id;
            response.Name = result.Name;
            response.HitPoints = result.HitPoints;
            response.Strength = result.Strength;
            response.Defense = result.Defense;
            response.Intelligence = result.Intelligence;
            response.Class = result.Class;

            return response;
        }
    }
}
