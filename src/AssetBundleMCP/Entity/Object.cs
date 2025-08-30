using System.Text.Json.Serialization;

namespace AssetBundleMcp.Entity;

public record Object
{
    [JsonPropertyName("id")] public required long Id { get; init; }

    [JsonPropertyName("object_id")] public required long ObjectId { get; init; }

    [JsonPropertyName("asset_bundle")] public required string AssetBundle { get; init; }

    [JsonPropertyName("serialized_file")] public required string SerializedFile { get; init; }

    [JsonPropertyName("type")] public required string Type { get; init; }

    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("game_object")] public required long GameObject { get; init; }

    [JsonPropertyName("size")] public required long Size { get; init; }

    [JsonPropertyName("pretty_size")] public required string PrettySize { get; init; }

    [JsonPropertyName("crc32")] public required long Crc32 { get; init; }
}