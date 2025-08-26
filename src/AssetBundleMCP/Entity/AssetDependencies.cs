using System.Text.Json.Serialization;

namespace AssetBundleMcp.Entity;

public record AssetDependencies
{
    [JsonPropertyName("id")] public required long Id { get; init; }

    [JsonPropertyName("asset_name")] public required string AssetName { get; init; }

    [JsonPropertyName("asset_bundle")] public required string AssetBundle { get; init; }

    [JsonPropertyName("type")] public required string Type { get; init; }

    [JsonPropertyName("dep_id")] public required long DepId { get; init; }

    [JsonPropertyName("dep_asset_bundle")] public required string DepAssetBundle { get; init; }

    [JsonPropertyName("dep_name")] public required string DepName { get; init; }

    [JsonPropertyName("dep_type")] public required string DepType { get; init; }
}