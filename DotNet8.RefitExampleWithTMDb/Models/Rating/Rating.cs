using System.Text.Json.Serialization;

namespace DotNet8.RefitExampleWithTMDb.Models.Rating;

public class Rating
{
    [JsonPropertyName("value")]
    public decimal Value { get; set; }
}

public class ResponseBody
{
    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }

    [JsonPropertyName("status_message")]
    public string StatusMessage { get; set; }
}