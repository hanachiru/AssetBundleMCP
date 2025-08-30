using System.Text.Json.Serialization;

namespace AssetBundleMcp.Entity;

public record MaterialShaderRefs
{
    [JsonPropertyName("material_id")] public required long MaterialId { get; init; }

    [JsonPropertyName("material_name")] public required string MaterialName { get; init; }

    [JsonPropertyName("material_path")] public required string MaterialPath { get; init; }

    [JsonPropertyName("material_asset_bundle")]
    public required string MaterialAssetBundle { get; init; }

    [JsonPropertyName("shader_id")] public required long ShaderId { get; init; }

    [JsonPropertyName("shader_name")] public required string ShaderName { get; init; }

    [JsonPropertyName("shader_asset_bundle")]
    public required string ShaderAssetBundle { get; init; }
}