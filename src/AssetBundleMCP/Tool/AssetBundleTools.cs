using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssetBundleMcpServer.Internal;
using AssetBundleMcpServer.Entity;
using AssetBundleMcpServer.Repository;
using ModelContextProtocol;
using ModelContextProtocol.Server;
using UnityDataTools.Analyzer;
using UnityDataTools.FileSystem;
using Object = AssetBundleMcpServer.Entity.Object;

namespace AssetBundleMcpServer.Tool;

[McpServerToolType, Description("MCP Server for Unity AssetBundle Reverse Engineering")]
public static class AssetBundleTools
{
    // NOTE: I added the static modifier because the state could not be shared between Tools in the MCP Server without it.
    //       I may change how this status is maintained.
    public static string? DatabasePath { get; private set; }
    public static bool IsLoaded() => !string.IsNullOrEmpty(DatabasePath) && File.Exists(DatabasePath);

    [McpServerTool, Description("Load a AssetBundle for analysis")]
    public static string LoadAssetBundle(
        [Description("A path to the directory or files to analyze.")]
        string assetBundlePath,
        [Description(
            "Optional: The path to the database file to save the analysis results. If not provided, a default name will be used.")]
        string? databaseFilePath = null
    )
    {
        if (!Directory.Exists(assetBundlePath) && !File.Exists(assetBundlePath))
        {
            throw new McpException($"Failed to load AssetBundle. Directory or File does not exist: {assetBundlePath}");
        }
        var isFile = File.Exists(assetBundlePath);

        try
        {
            UnityFileSystem.Init();
            var analyzer = new AnalyzerTool();
            
            databaseFilePath ??= Path.Combine(Directory.GetCurrentDirectory(), $"{Guid.NewGuid()}.db");
            var result = analyzer.Analyze(
                isFile ? Directory.GetParent(assetBundlePath)!.FullName : assetBundlePath,
                databaseFilePath,
                isFile ? Path.GetFileNameWithoutExtension(assetBundlePath) : "*",
                false,
                false,
                false
            );

            if (result != 0)
            {
                throw new McpException(
                    "[ERROR] Failed to analyze AssetBundle. Please check the logs for more details.");
            }

            DatabasePath = databaseFilePath;
            return
                $"Analysis complete. Output saved to {databaseFilePath}. Remember to call UnLoadAssetBundle to free resources when done.";
        }
        catch (Exception ex)
        {
            throw new McpException($"[ERROR] Failed to parse AssetBundle: {ex.Message}");
        }
    }

    [McpServerTool, Description("UnLoad database file")]
    public static string UnLoadAssetBundle()
    {
        if (!IsLoaded())
        {
            throw new McpException("No AssetBundle loaded or database file not found.");
        }

        try
        {
            File.Delete(DatabasePath!);
            DatabasePath = null;
            return "AssetBundle unloaded successfully.";
        }
        catch (Exception ex)
        {
            throw new McpException($"[ERROR] Failed to unload AssetBundle: {ex.Message}");
        }
    }

    [McpServerTool, Description("List all animations in Assetbundle")]
    public static Animation[] ListAnimations(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetAnimations(DatabasePath!));
    }

    [McpServerTool, Description("List all asset dependencies in Assetbundle")]
    public static AssetDependencies[] ListAssetDependencies(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetAssetDependencies(DatabasePath!));
    }

    [McpServerTool, Description("List all asset in Assetbundle")]
    public static Asset[] ListAssets(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetAssets(DatabasePath!));
    }

    [McpServerTool, Description("List all audio clips in Assetbundle")]
    public static AudioClip[] ListAudioClips(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetAudioClips(DatabasePath!));
    }

    [McpServerTool, Description("List all meshes in Assetbundle")]
    public static Mesh[] ListMeshes(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetMeshes(DatabasePath!));
    }

    [McpServerTool, Description("List all objects in Assetbundle")]
    public static Object[] ListObjects(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetObjects(DatabasePath!));
    }

    [McpServerTool, Description("List all shader keyword ratios in Assetbundle")]
    public static ShaderKeywordRatio[] ListShaderKeywordRatios(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetShaderKeywordRatios(DatabasePath!));
    }

    [McpServerTool, Description("List all shader subprograms in Assetbundle")]
    public static ShaderSubprogram[] ListShaderSubprograms(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetShaderSubprograms(DatabasePath!));
    }

    [McpServerTool, Description("List all shaders in Assetbundle")]
    public static Shader[] ListShaders(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetShaders(DatabasePath!));
    }

    [McpServerTool, Description("List all textures in Assetbundle")]
    public static Texture[] ListTextures(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetTextures(DatabasePath!));
    }

    [McpServerTool, Description("List all breakdown by type in Assetbundle")]
    public static BreakdownByType[] ListBreakdownByType(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetBreakdownByType(DatabasePath!));
    }

    [McpServerTool, Description("List all breakdown shaders in Assetbundle")]
    public static BreakdownShaders[] ListBreakdownShaders(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetBreakdownShaders(DatabasePath!));
    }

    [McpServerTool, Description("List all material shader references in Assetbundle")]
    public static MaterialShaderRefs[] ListMaterialShaderRefs(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetMaterialShaderRefs(DatabasePath!));
    }

    [McpServerTool, Description("List all material texture references in Assetbundle")]
    public static MaterialTextureRefs[] ListMaterialTextureRefs(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetMaterialTextureRefs(DatabasePath!));
    }

    [McpServerTool, Description("List all potential duplicates in Assetbundle")]
    public static PotentialDuplicates[] ListPotentialDuplicates(
        IAssetRepository repository,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.GetPotentialDuplicates(DatabasePath!));
    }

    [McpServerTool,
     Description(
         "Execute a SQL query on the AssetBundle database.Please call GetAssetBundleSchema in the Resources of MCPServer to reference the schema.")]
    public static string[] ExecuteSqlQuery(
        IAssetRepository repository,
        [Description("The SQL query to execute. Ensure it is a valid query for the AssetBundle database schema.")]
        string query,
        [Description("Offset to start listing from(start at 0)")]
        int offset = 0,
        [Description("Number of items to list(100 is a good number,0 means remainder)")]
        int pageSize = 100
    )
    {
        return GetData(repository, offset, pageSize, repo => repo.ExecuteCustomQuery(DatabasePath!, query));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T[] GetData<T>(
        IAssetRepository repository,
        int offset,
        int pageSize,
        Func<IAssetRepository, IEnumerable<T>> repositoryCall
    )
    {
        try
        {
            if (!IsLoaded())
            {
                throw new McpException("Database file not found. Please run LoadAssetBundle command first.");
            }

            var result = repositoryCall(repository);
            return Paginate.Execute(result, offset, pageSize).ToArray();
        }
        catch (Exception ex)
        {
            throw new McpException($"An unexpected error has occurred: {ex.Message}");
        }
    }
}