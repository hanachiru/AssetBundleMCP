
using AssetBundleMcp.Entity;
using Object = AssetBundleMcp.Entity.Object;

namespace AssetBundleMcp.Service;

public interface IAssetBundleService
{
    string LoadAssetBundle(string assetBundlePath, string? databaseFilePath = null);
    string UnLoadAssetBundle();
    Animation[] ListAnimations(int offset = 0, int pageSize = 100);
    AssetDependencies[] ListAssetDependencies(int offset = 0, int pageSize = 100);
    Asset[] ListAssets(int offset = 0, int pageSize = 100);
    AudioClip[] ListAudioClips(int offset = 0, int pageSize = 100);
    Mesh[] ListMeshes(int offset = 0, int pageSize = 100);
    Object[] ListObjects(int offset = 0, int pageSize = 100);
    ShaderKeywordRatio[] ListShaderKeywordRatios(int offset = 0, int pageSize = 100);
    ShaderSubprogram[] ListShaderSubprograms(int offset = 0, int pageSize = 100);
    Shader[] ListShaders(int offset = 0, int pageSize = 100);
    Texture[] ListTextures(int offset = 0, int pageSize = 100);
    BreakdownByType[] ListBreakdownByType(int offset = 0, int pageSize = 100);
    BreakdownShaders[] ListBreakdownShaders(int offset = 0, int pageSize = 100);
    MaterialShaderRefs[] ListMaterialShaderRefs(int offset = 0, int pageSize = 100);
    MaterialTextureRefs[] ListMaterialTextureRefs(int offset = 0, int pageSize = 100);
    PotentialDuplicates[] ListPotentialDuplicates(int offset = 0, int pageSize = 100);
    string[] ExecuteSqlQuery(string query, int offset = 0, int pageSize = 100);
}
