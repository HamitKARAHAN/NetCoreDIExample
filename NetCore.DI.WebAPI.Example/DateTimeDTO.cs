using System.Text.Json.Serialization;

namespace NetCore.DI.WebAPI.Example
{
    public class DateTimeDTO
    {
        [JsonPropertyName("DateTimeWithCI")] public TimeSpan DateTime1 { get; init; }
        [JsonPropertyName("DateTimeWithMI")] public TimeSpan DateTime2 { get; init; }
    }
}