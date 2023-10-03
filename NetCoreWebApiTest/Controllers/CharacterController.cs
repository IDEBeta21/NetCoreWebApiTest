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
        [Route("GetAllCharactes")]
        public IActionResult GetAllCharacters()
        {
            List<GetCharacterResponse> result = _characterServices.GetAllCharacters();

            return Ok(result);
        }
    }
}
