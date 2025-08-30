using System.Text.Json.Serialization;

namespace AssetBundleMcp.Entity;

public record BreakdownShaders
{
    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("instances")] public required string Instances { get; init; }

    [JsonPropertyName("pretty_total_size")]
    public required string PrettyTotalSize { get; init; }

    [JsonPropertyName("total_size")] public required string TotalSize { get; init; }

    [JsonPropertyName("in_bundles")] public required string InBundles { get; init; }
}