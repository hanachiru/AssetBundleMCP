using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AssetBundleMcpServer.Entity;

public record Animation
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

    [JsonPropertyName("pretty_size")]
    [Description("Size in kilobytes")]
    public required string PrettySize { get; init; }

    [JsonPropertyName("crc32")] public required long Crc32 { get; init; }

    [JsonPropertyName("legacy")] public required long Legacy { get; init; }

    [JsonPropertyName("events")] public required long Events { get; init; }
}