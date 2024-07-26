using DotNet8.RefitExampleWithTMDb.Models.Actor;
using DotNet8.RefitExampleWithTMDb.Models.Movie;
using DotNet8.RefitExampleWithTMDb.Models.Rating;
using Refit;

namespace DotNet8.RefitExampleWithTMDb.Services;

[Headers("accept: application/json", "Authorization: Bearer")]
public interface ITmdbApi
{
    [Get("/search/person?query={name}")]
    Task<ActorList> GetActors(string name);

    [Get("/person/{actorId}/movie_credits?language=en-US")]
    Task<MovieList> GetMovies(int actorId);

    [Headers("Content-Type: application/json;charset=utf-8")]
    [Post("/movie/{movieId}/rating")]
    Task<ResponseBody> AddRating(int movieId, [Body] Rating rating);

    [Delete("/movie/{movieId}/rating")]
    Task<ResponseBody> DeleteRating(int movieId);
}