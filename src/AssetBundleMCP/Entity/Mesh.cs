using System.Text.Json.Serialization;

namespace AssetBundleMcpServer.Entity;

public record Mesh
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

    [JsonPropertyName("sub_meshes")] public required long SubMeshes { get; init; }

    [JsonPropertyName("blend_shapes")] public required long BlendShapes { get; init; }

    [JsonPropertyName("bones")] public required long Bones { get; init; }

    [JsonPropertyName("indices")] public required long Indices { get; init; }

    [JsonPropertyName("vertices")] public required long Vertices { get; init; }

    [JsonPropertyName("compression")] public required long Compression { get; init; }

    [JsonPropertyName("rw_enabled")] public required long RwEnabled { get; init; }

    [JsonPropertyName("vertex_size")] public required long VertexSize { get; init; }

    [JsonPropertyName("channels")] public required string Channels { get; init; }
}