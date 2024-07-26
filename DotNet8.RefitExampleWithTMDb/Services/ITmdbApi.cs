using DotNet8.RefitExampleWithTMDb.Models.Actor;
using Refit;

namespace DotNet8.RefitExampleWithTMDb.Services
{
    [Headers("accept: application/json", "Authorization: Bearer")]
    public interface ITmdbApi
    {
        [Get("/search/person?query={name}")]
        Task<ActorList> GetActors(string name);
    }
}