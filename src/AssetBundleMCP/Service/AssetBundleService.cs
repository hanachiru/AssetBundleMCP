using System.Runtime.CompilerServices;
using AssetBundleMcp.Entity;
using AssetBundleMcp.Internal;
using AssetBundleMcp.Repository;
using ModelContextProtocol;
using Object = AssetBundleMcp.Entity.Object;

namespace AssetBundleMcp.Service;

public class AssetBundleService : IAssetBundleService
{
    public string? DatabasePath { get; private set; }
    public bool IsLoaded => !string.IsNullOrEmpty(DatabasePath) && File.Exists(DatabasePath);
    
    private readonly IAssetRepository _repository;
    private readonly IAnalyzerService _analyzerService;

    public AssetBundleService(IAssetRepository repository, IAnalyzerService analyzerService)
    {
        _repository = repository;
        _analyzerService = analyzerService;
    }

    public string LoadAssetBundle(string assetBundlePath, string? databaseFilePath = null)
    {
        if (IsLoaded)
        {
            UnLoadAssetBundle();
        }

        var generatedDbPath = _analyzerService.Analyze(assetBundlePath, databaseFilePath); 
        DatabasePath = generatedDbPath;

        return
            $"Analysis complete. Output saved to {generatedDbPath}. Remember to call UnLoadAssetBundle to free resources when done.";
    }

    public string UnLoadAssetBundle()
    {
        if (!IsLoaded)
        {
            throw new McpException("No AssetBundle loaded or database file not found.");
        }

        try
        {
            _repository.RefreshCache();
            _analyzerService.Unload(DatabasePath!);
            DatabasePath = null;
            return "AssetBundle unloaded successfully.";
        }
        catch (Exception ex)
        {
            throw new McpException($"[ERROR] Failed to unload AssetBundle: {ex.Message}");
        }
    }

    public Animation[] ListAnimations(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetAnimations(DatabasePath!));

    public AssetDependencies[] ListAssetDependencies(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetAssetDependencies(DatabasePath!));

    public Asset[] ListAssets(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetAssets(DatabasePath!));

    public AudioClip[] ListAudioClips(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetAudioClips(DatabasePath!));

    public Mesh[] ListMeshes(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetMeshes(DatabasePath!));

    public Object[] ListObjects(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetObjects(DatabasePath!));

    public ShaderKeywordRatio[] ListShaderKeywordRatios(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetShaderKeywordRatios(DatabasePath!));

    public ShaderSubprogram[] ListShaderSubprograms(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetShaderSubprograms(DatabasePath!));

    public Shader[] ListShaders(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetShaders(DatabasePath!));

    public Texture[] ListTextures(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetTextures(DatabasePath!));

    public BreakdownByType[] ListBreakdownByType(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetBreakdownByType(DatabasePath!));

    public BreakdownShaders[] ListBreakdownShaders(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetBreakdownShaders(DatabasePath!));

    public MaterialShaderRefs[] ListMaterialShaderRefs(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetMaterialShaderRefs(DatabasePath!));

    public MaterialTextureRefs[] ListMaterialTextureRefs(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetMaterialTextureRefs(DatabasePath!));

    public PotentialDuplicates[] ListPotentialDuplicates(int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.GetPotentialDuplicates(DatabasePath!));

    public string[] ExecuteSqlQuery(string query, int offset = 0, int pageSize = 100) =>
        GetData(offset, pageSize, repo => repo.ExecuteCustomQuery(DatabasePath!, query));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T[] GetData<T>(
        int offset,
        int pageSize,
        Func<IAssetRepository, IEnumerable<T>> repositoryCall
    )
    {
        try
        {
            if (!IsLoaded)
            {
                throw new McpException("Database file not found. Please run LoadAssetBundle command first.");
            }

            var result = repositoryCall(_repository);
            return Paginate.Execute(result, offset, pageSize).ToArray();
        }
        catch (Exception ex)
        {
            throw new McpException($"An unexpected error has occurred: {ex.Message}");
        }
    }
}