using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NetCoreWebApiTest.DOTs;
using NetCoreWebApiTest.Model;

namespace NetCoreWebApiTest.Services
{
    public class CharacterServices : ICharacterServices
    {
        private readonly string? _conString;
        private readonly string? _dbName;
        private readonly string? _characterCollectionName;
        private IMongoDatabase _db;
        public CharacterServices(IConfiguration configuration)
        {
            this._conString = "mongodb://localhost:27017";
            this._dbName = "dotnet-rpg";
            this._characterCollectionName = "characters";

            var client = new MongoClient(configuration.GetConnectionString("DbConnection"));
            this._db = client.GetDatabase(configuration.GetConnectionString("CharacterDb"));
        }

        public List<GetCharacterResponse> GetAllCharacters()
        {
            var collection = _db.GetCollection<GetCharacterResponse>(_characterCollectionName);

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
            var AddCharacterCollection = _db.GetCollection<AddCharacterRequest>(_characterCollectionName);

            //Add new Character
            AddCharacterCollection.InsertOne(request);

            //Return Character
            var GetCharacterCollection = _db.GetCollection<AddCharacterResponse>(_characterCollectionName);
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

            var collection = _db.GetCollection<GetSingleCharacterResponse>(_characterCollectionName);

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

        public List<DeleteCharacterByIdResponse> DeleteCharacterById(DeleteCharacterByIdRequest request)
        {
            var DeleteCharacterCollection = _db.GetCollection<DeleteCharacterByIdResponse>(_characterCollectionName);

            var objectIdToFind = new ObjectId(request.Id);
            var filter = Builders<DeleteCharacterByIdResponse>.Filter.Eq("_id", objectIdToFind);

            //Delete a Character
            DeleteCharacterCollection.DeleteOne(filter);

            //Return Character
            var GetCharacterCollection = _db.GetCollection<DeleteCharacterByIdResponse>(_characterCollectionName);
            var results = GetCharacterCollection.Find(_ => true);
            List<DeleteCharacterByIdResponse> response = new List<DeleteCharacterByIdResponse>();

            //for debugging
            var resList = results.ToList();

            foreach (var result in resList)
            {
                response.Add(new DeleteCharacterByIdResponse()
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

        public List<GetAllCharacterNameResponse> GetAllCharacterName()
        {
            var collection = _db.GetCollection<GetAllCharacterNameResponse>(_characterCollectionName);

            var results = collection.Find(_ => true).Project(x => new {x.Id, x.Name});

            //var projection = Builders<Character>
            //                    .Projection
            //                    .Include(x => x.Id).Include(x => x.Name);

            //var results = collection.Find(x => true)
            //                .Project<GetAllCharacterNameResponse>(projection);

            List<GetAllCharacterNameResponse> response = new List<GetAllCharacterNameResponse>();

            //for debugging
            var resList = results.ToList();

            foreach (var result in resList)
            {
                response.Add(new GetAllCharacterNameResponse()
                {
                    Id = result.Id.ToString(),
                    Name = result.Name
                }); ;
            }

            return response;
        }
    }
}
