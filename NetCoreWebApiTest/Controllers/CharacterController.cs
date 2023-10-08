using Microsoft.AspNetCore.Mvc;
using NetCoreWebApiTest.DOTs;
using NetCoreWebApiTest.Services;
using NetCoreWebApiTest.Model;

namespace NetCoreWebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterServices _characterServices;
        public CharacterController(ICharacterServices characterServices)
        {
            _characterServices = characterServices;
        }

        [HttpGet]
        [Route("GetAllCharacters")]
        public IActionResult GetAllCharacters()
        {
            List<GetCharacterResponse> result = _characterServices.GetAllCharacters();

            return Ok(result);
        }

        [HttpPost]
        [Route("GetSingleCharacterById")]
        public IActionResult GetSingleCharacter(GetSingleCharacterRequest request)
        {
            GetSingleCharacterResponse result = _characterServices.GetSingleCharacterById(request);

            return Ok(result);
        }

        [HttpPost]
        [Route("AddCharacter")]
        public IActionResult AddCharacter(AddCharacterRequest request)
        {
            List<AddCharacterResponse> result = _characterServices.AddCharacter(request);

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteCharacter")]
        public IActionResult DeleteCharacter(DeleteCharacterByIdRequest request)
        {
            List<DeleteCharacterByIdResponse> result = _characterServices.DeleteCharacterById(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllCharacterName")]
        public IActionResult GetAllCharacterName()
        {
            List<GetAllCharacterNameResponse> result = _characterServices.GetAllCharacterName();

            return Ok(result);
        }

    }
}
