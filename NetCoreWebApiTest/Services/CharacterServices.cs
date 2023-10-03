using NetCoreWebApiTest.DOTs;

namespace NetCoreWebApiTest.Services
{
    public class CharacterServices : ICharacterServices
    {
        public List<GetCharacterResponse> GetAllCharacters()
        {
            //throw new NotImplementedException();
            List<GetCharacterResponse> response = new List<GetCharacterResponse>();

            for (int aa = 0; aa < 5; aa++ ) 
            {
                response.Add(new GetCharacterResponse()
                {
                    Id = 1,
                    Name = "Ian",
                    HitPoints = 100,
                    Strength = 1,
                    Defense = 1,
                    Intelligence = 1,
                    Class = Model.RPGClass.Knight
                });
            }

            return response;
        }
    }
}
