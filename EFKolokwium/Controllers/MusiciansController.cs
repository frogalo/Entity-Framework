using System.Threading.Tasks;
using EFKolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFKolokwium.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusiciansController : Controller
    {
        private readonly IDbService _dbService;
        public MusiciansController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete("{idMusician}")]
        public async Task<IActionResult> Removetrack(int idMusician)
        {
            if(await _dbService.RemoveMusician(idMusician)) return Ok("Musician removed");
            else return NotFound("Musician not found");
        }
    }
}