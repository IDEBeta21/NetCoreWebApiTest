using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using NetCoreWebApiTest.DOTs;

namespace NetCoreWebApiTest.Services
{
    public interface ICharacterServices
    {
        List<GetCharacterResponse> GetAllCharacters();
        List<AddCharacterResponse> AddCharacter(AddCharacterRequest request);
        GetSingleCharacterResponse GetSingleCharacterById(GetSingleCharacterRequest request);
        List<DeleteCharacterByIdResponse> DeleteCharacterById(DeleteCharacterByIdRequest request);
        List<GetAllCharacterNameResponse> GetAllCharacterName();
    }
}
