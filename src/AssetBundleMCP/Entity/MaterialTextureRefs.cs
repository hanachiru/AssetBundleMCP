using System.Text.Json.Serialization;

namespace AssetBundleMcpServer.Entity;

public record MaterialTextureRefs
{
    [JsonPropertyName("material_id")] public required long MaterialId { get; init; }

    [JsonPropertyName("material_name")] public required string MaterialName { get; init; }

    [JsonPropertyName("material_path")] public required string MaterialPath { get; init; }

    [JsonPropertyName("material_asset_bundle")]
    public required string MaterialAssetBundle { get; init; }

    [JsonPropertyName("texture_id")] public required long TextureId { get; init; }

    [JsonPropertyName("texture_name")] public required string TextureName { get; init; }

    [JsonPropertyName("texture_asset_bundle")]
    public required string TextureAssetBundle { get; init; }
}