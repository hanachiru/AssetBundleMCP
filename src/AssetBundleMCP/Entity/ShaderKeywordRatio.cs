using System.Text.Json.Serialization;

namespace AssetBundleMcpServer.Entity;

public record ShaderKeywordRatio
{
    [JsonPropertyName("shader_id")] public required long ShaderId { get; init; }

    [JsonPropertyName("name")] public required string Name { get; init; }

    [JsonPropertyName("sub_shader")] public required long SubShader { get; init; }

    [JsonPropertyName("hw_tier")] public required long HwTier { get; init; }

    [JsonPropertyName("pass")] public required long Pass { get; init; }

    [JsonPropertyName("api")] public required string Api { get; init; }

    [JsonPropertyName("pass_name")] public required string PassName { get; init; }

    [JsonPropertyName("shader_type")] public required string ShaderType { get; init; }

    [JsonPropertyName("total_variants")] public required string TotalVariants { get; init; }

    [JsonPropertyName("keyword")] public required string Keyword { get; init; }

    [JsonPropertyName("variants")] public required string Variants { get; init; }

    [JsonPropertyName("ratio")] public required string Ratio { get; init; }
}