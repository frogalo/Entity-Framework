using System.Threading.Tasks;
using EFKolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFKolokwium.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsController : Controller
    {
        
        private readonly IDbService _dbService;
        public AlbumsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idAlbum}")]
        public async Task<IActionResult> GetAlbum(int idAlbum)
        {
            return Ok(await _dbService.GetAlbum(idAlbum));
        }

    }
}
