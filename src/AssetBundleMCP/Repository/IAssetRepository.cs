
using AssetBundleMcpServer.Entity;

namespace AssetBundleMcpServer.Repository;

public interface IAssetRepository
{
    public Animation[] GetAnimations(string dbPath);
    public AssetDependencies[] GetAssetDependencies(string dbPath);
    public Asset[] GetAssets(string dbPath);
    public AudioClip[] GetAudioClips(string dbPath);
    public Mesh[] GetMeshes(string dbPath);
    public Entity.Object[] GetObjects(string dbPath);
    public ShaderKeywordRatio[] GetShaderKeywordRatios(string dbPath);
    public ShaderSubprogram[] GetShaderSubprograms(string dbPath);
    public Shader[] GetShaders(string dbPath);
    public Texture[] GetTextures(string dbPath);
    public BreakdownByType[] GetBreakdownByType(string dbPath);
    public BreakdownShaders[] GetBreakdownShaders(string dbPath);
    public MaterialShaderRefs[] GetMaterialShaderRefs(string dbPath);
    public MaterialTextureRefs[] GetMaterialTextureRefs(string dbPath);
    public PotentialDuplicates[] GetPotentialDuplicates(string dbPath);
    public string[] ExecuteCustomQuery(string dbPath, string query);
}