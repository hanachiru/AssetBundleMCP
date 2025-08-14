using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AssetBundleMcpServer.Entity;

public record Texture
{
    [JsonPropertyName("id")] public required long Id { get; init; }

    [JsonPropertyName("object_id")] public required long ObjectId { get; init; }

    [JsonPropertyName("asset_bundle")] public required string AssetBundle { get; init; }

    [JsonPropertyName("serialized_file")] public required string SerializedFile { get; init; }

    [JsonPropertyName("type")] public required string Type { get; init; }

    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("game_object")] public required long GameObject { get; init; }

    [JsonPropertyName("size")]
    [Description("Size in bytes")]
    public required long Size { get; init; }

    [JsonPropertyName("pretty_size")] public required string PrettySize { get; init; }

    [JsonPropertyName("crc32")] public required long Crc32 { get; init; }

    [JsonPropertyName("width")] public required long Width { get; init; }

    [JsonPropertyName("height")] public required long Height { get; init; }

    [JsonPropertyName("format")] public required string Format { get; init; }

    [JsonPropertyName("mip_count")] public required long MipCount { get; init; }

    [JsonPropertyName("rw_enabled")] public required long RwEnabled { get; init; }
}