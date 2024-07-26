using DotNet8.RefitExampleWithTMDb.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace DotNet8.RefitExampleWithTMDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDbController : ControllerBase
    {
        private readonly ITmdbApi _tmdbApi;

        public MovieDbController(ITmdbApi tmdbApi)
        {
            _tmdbApi = tmdbApi;
        }

        [HttpGet("actors")]
        public async Task<IActionResult> GetActors([FromQuery] string name)
        {
            try
            {
                var response = await _tmdbApi.GetActors(name);
                return Ok(response);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }
    }
}
