using DotNet8.RefitExampleWithTMDb.Models.Actor;
using DotNet8.RefitExampleWithTMDb.Models.Movie;
using DotNet8.RefitExampleWithTMDb.Models.Rating;
using DotNet8.RefitExampleWithTMDb.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        [HttpGet("actors/{actorId}/movies")]
        public async Task<IActionResult> GetMovies(int actorId)
        {
            try
            {
                var response = await _tmdbApi.GetMovies(actorId);
                return Ok(response);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }

        [HttpPost("movies/{movieId}/rating")]
        public async Task<IActionResult> AddRating(int movieId, [FromBody] Rating rating)
        {
            try
            {
                var response = await _tmdbApi.AddRating(movieId, rating);
                return Ok(response);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }

        [HttpDelete("movies/{movieId}/rating")]
        public async Task<IActionResult> DeleteRating(int movieId)
        {
            try
            {
                var response = await _tmdbApi.DeleteRating(movieId);
                return Ok(response);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }
    }
}
