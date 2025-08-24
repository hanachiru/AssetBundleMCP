using System.Text.Json.Serialization;

namespace AssetBundleMcpServer.Entity;

public record PotentialDuplicates
{
    [JsonPropertyName("instances")] public required string Instances { get; init; }

    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("type")] public required string Type { get; init; }

    [JsonPropertyName("pretty_total_size")]
    public required string PrettyTotalSize { get; init; }

    [JsonPropertyName("total_size")] public required string TotalSize { get; init; }

    [JsonPropertyName("size")] public required long Size { get; init; }

    [JsonPropertyName("pretty_size")] public required string PrettySize { get; init; }

    [JsonPropertyName("in_files")] public required string InFiles { get; init; }
}