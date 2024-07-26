using System.Text.Json.Serialization;

namespace DotNet8.RefitExampleWithTMDb.Models.Movie;

public class Movie
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
}

public class MovieList
{
    [JsonPropertyName("cast")]
    public List<Movie> Movies { get; set; }
}