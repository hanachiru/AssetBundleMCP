using System.Text.Json.Serialization;

namespace AssetBundleMcpServer.Entity;

public record ShaderSubprogram
{
    [JsonPropertyName("shader_id")] public required long ShaderId { get; init; }

    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("sub_shader")] public required long SubShader { get; init; }

    [JsonPropertyName("hw_tier")] public required long HwTier { get; init; }

    [JsonPropertyName("api")] public required string Api { get; init; }

    [JsonPropertyName("pass")] public required long Pass { get; init; }

    [JsonPropertyName("pass_name")] public required string PassName { get; init; }

    [JsonPropertyName("shader_type")] public required string ShaderType { get; init; }

    [JsonPropertyName("sub_program")] public required long SubProgram { get; init; }

    [JsonPropertyName("keywords")] public required string Keywords { get; init; }
}