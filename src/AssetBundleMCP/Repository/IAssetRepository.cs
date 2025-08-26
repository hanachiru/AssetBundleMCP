using AssetBundleMcp.Entity;
using Object = AssetBundleMcp.Entity.Object;

namespace AssetBundleMcp.Repository;

public interface IAssetRepository
{
    Animation[] GetAnimations(string dbPath);
    AssetDependencies[] GetAssetDependencies(string dbPath);
    Asset[] GetAssets(string dbPath);
    AudioClip[] GetAudioClips(string dbPath);
    Mesh[] GetMeshes(string dbPath);
    Object[] GetObjects(string dbPath);
    ShaderKeywordRatio[] GetShaderKeywordRatios(string dbPath);
    ShaderSubprogram[] GetShaderSubprograms(string dbPath);
    Shader[] GetShaders(string dbPath);
    Texture[] GetTextures(string dbPath);
    BreakdownByType[] GetBreakdownByType(string dbPath);
    BreakdownShaders[] GetBreakdownShaders(string dbPath);
    MaterialShaderRefs[] GetMaterialShaderRefs(string dbPath);
    MaterialTextureRefs[] GetMaterialTextureRefs(string dbPath);
    PotentialDuplicates[] GetPotentialDuplicates(string dbPath);
    string[] ExecuteCustomQuery(string dbPath, string query);
    void RefreshCache();
}