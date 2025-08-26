using System.Text.Json.Serialization;

namespace AssetBundleMcp.Entity;

public record BreakdownByType
{
    [JsonPropertyName("type")] public required string Type { get; init; }

    [JsonPropertyName("count")] public required string Count { get; init; }

    [JsonPropertyName("byte_size")] public required string ByteSize { get; init; }

    [JsonPropertyName("pretty_size")] public required string PrettySize { get; init; }
}