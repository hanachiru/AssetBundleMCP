
using System.ComponentModel;
using AssetBundleMcp.Entity;
using AssetBundleMcp.Service;
using ModelContextProtocol.Server;
using Object = AssetBundleMcp.Entity.Object;

namespace AssetBundleMcp.Tool;

[McpServerToolType, Description("MCP Server for Unity AssetBundle Reverse Engineering")]
public static class AssetBundleTools
{
    [McpServerTool, Description("Load an AssetBundle for analysis")]
    public static string LoadAssetBundle(
        IAssetBundleService service,
        [Description("A path to the directory or files to analyze.")]
        string assetBundlePath,
        [Description(
            "Optional: The path to the database file to save the analysis results. If not provided, a default name will be used.")]
        string? databaseFilePath = null
    )
    {
        return service.LoadAssetBundle(assetBundlePath, databaseFilePath);
    }

    [McpServerTool, Description("UnLoad database file")]
    public static string UnLoadAssetBundle(IAssetBundleService service)
    {
        return service.UnLoadAssetBundle();
    }

    [McpServerTool, Description("List all animations in Assetbundle")]
    public static Animation[] ListAnimations(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListAnimations(offset, pageSize);
    }

    [McpServerTool, Description("List all asset dependencies in Assetbundle")]
    public static AssetDependencies[] ListAssetDependencies(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListAssetDependencies(offset, pageSize);
    }

    [McpServerTool, Description("List all asset in Assetbundle")]
    public static Asset[] ListAssets(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListAssets(offset, pageSize);
    }

    [McpServerTool, Description("List all audio clips in Assetbundle")]
    public static AudioClip[] ListAudioClips(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListAudioClips(offset, pageSize);
    }

    [McpServerTool, Description("List all meshes in Assetbundle")]
    public static Mesh[] ListMeshes(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListMeshes(offset, pageSize);
    }

    [McpServerTool, Description("List all objects in Assetbundle")]
    public static Object[] ListObjects(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListObjects(offset, pageSize);
    }

    [McpServerTool, Description("List all shader keyword ratios in Assetbundle")]
    public static ShaderKeywordRatio[] ListShaderKeywordRatios(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListShaderKeywordRatios(offset, pageSize);
    }

    [McpServerTool, Description("List all shader subprograms in Assetbundle")]
    public static ShaderSubprogram[] ListShaderSubprograms(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListShaderSubprograms(offset, pageSize);
    }

    [McpServerTool, Description("List all shaders in Assetbundle")]
    public static Shader[] ListShaders(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListShaders(offset, pageSize);
    }

    [McpServerTool, Description("List all textures in Assetbundle")]
    public static Texture[] ListTextures(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListTextures(offset, pageSize);
    }

    [McpServerTool, Description("List all breakdown by type in Assetbundle")]
    public static BreakdownByType[] ListBreakdownByType(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListBreakdownByType(offset, pageSize);
    }

    [McpServerTool, Description("List all breakdown shaders in Assetbundle")]
    public static BreakdownShaders[] ListBreakdownShaders(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListBreakdownShaders(offset, pageSize);
    }

    [McpServerTool, Description("List all material shader references in Assetbundle")]
    public static MaterialShaderRefs[] ListMaterialShaderRefs(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListMaterialShaderRefs(offset, pageSize);
    }

    [McpServerTool, Description("List all material texture references in Assetbundle")]
    public static MaterialTextureRefs[] ListMaterialTextureRefs(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListMaterialTextureRefs(offset, pageSize);
    }

    [McpServerTool, Description("List all potential duplicates in Assetbundle")]
    public static PotentialDuplicates[] ListPotentialDuplicates(
        IAssetBundleService service,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ListPotentialDuplicates(offset, pageSize);
    }

    [McpServerTool,
     Description(
         "Execute a SQL query on the AssetBundle database.Please call GetAssetBundleSchema in the Resources of MCPServer to reference the schema.")]
    public static string[] ExecuteSqlQuery(
        IAssetBundleService service,
        [Description("The SQL query to execute. Ensure it is a valid query for the AssetBundle database schema.")]
        string query,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return service.ExecuteSqlQuery(query, offset, pageSize);
    }
}
