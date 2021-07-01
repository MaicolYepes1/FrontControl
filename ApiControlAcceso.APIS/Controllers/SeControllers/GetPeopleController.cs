using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.SeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPeopleController : ControllerBase
    {
        private readonly IGetAllPeople _people;

        public GetPeopleController(IGetAllPeople people)
        {
            _people = people;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _people.GetAllPeopleSe();

            return Ok(result);

        }
    }
}
