using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AssetBundleMcp.Entity;

public record Shader
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

    [JsonPropertyName("decompressed_size")]
    public required long DecompressedSize { get; init; }

    [JsonPropertyName("sub_shaders")] public required string SubShaders { get; init; }

    [JsonPropertyName("sub_programs")] public required string SubPrograms { get; init; }

    [JsonPropertyName("unique_programs")] public required long UniquePrograms { get; init; }

    [JsonPropertyName("keywords")] public required string Keywords { get; init; }
}