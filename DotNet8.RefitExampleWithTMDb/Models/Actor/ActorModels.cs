using System.Text.Json.Serialization;

namespace DotNet8.RefitExampleWithTMDb.Models.Actor;
public class Actor
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class ActorList
{
    [JsonPropertyName("results")]
    public List<Actor> Actors { get; set; }
}