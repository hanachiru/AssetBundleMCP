using AssetBundleMcp.Repository;
using AssetBundleMcp.Service;
using AssetBundleMcp.Tool;

namespace AssetBundleMCP.Tests;

public class Tests
{
    private string AssetBundleDirPath => Path.Combine(AppContext.BaseDirectory, "TestData");
    
    [Test]
    public void LoadAndUnLoadAssetBundle()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var loadedPath = assetBundleService.DatabasePath;
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);
        var unloadedPath = assetBundleService.DatabasePath;

        Assert.That(loadedPath, Is.Not.Null);
        Assert.That(unloadedPath, Is.Null);
    }
    
    [Test]
    public void ListAnimations()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var animations = AssetBundleTools.ListAnimations(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(animations, Is.Not.Null);
    }

    [Test]
    public void ListAssetDependencies()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var dependencies = AssetBundleTools.ListAssetDependencies(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(dependencies, Is.Not.Null);
    }

    [Test]
    public void ListAssets()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var assets = AssetBundleTools.ListAssets(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(assets, Is.Not.Null);
    }

    [Test]
    public void ListAudioClips()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var audioClips = AssetBundleTools.ListAudioClips(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(audioClips, Is.Not.Null);
    }

    [Test]
    public void ListMeshes()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var meshes = AssetBundleTools.ListMeshes(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(meshes, Is.Not.Null);
    }

    [Test]
    public void ListObjects()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var objects = AssetBundleTools.ListObjects(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);         

        Assert.That(objects, Is.Not.Null);
    }

    [Test]
    public void ListShaderKeywordRatios()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var shaderKeywords = AssetBundleTools.ListShaderKeywordRatios(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(shaderKeywords, Is.Not.Null);
    }

    [Test]
    public void ListShaderSubprograms()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var shaderSubprograms = AssetBundleTools.ListShaderSubprograms(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(shaderSubprograms, Is.Not.Null);
    }

    [Test]
    public void ListShaders()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var shaders = AssetBundleTools.ListShaders(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(shaders, Is.Not.Null);
    }

    [Test]
    public void ListTextures()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var textures = AssetBundleTools.ListTextures(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(textures, Is.Not.Null);
    }

    [Test]
    public void BreakdownByType()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var breakdown = AssetBundleTools.ListBreakdownByType(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(breakdown, Is.Not.Null);
    }

    [Test]
    public void BreakdownShaders()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var breakdownShaders = AssetBundleTools.ListBreakdownShaders(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(breakdownShaders, Is.Not.Null);
    }

    [Test]
    public void ListMaterialShaderRefs()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var materialShaderRefs = AssetBundleTools.ListMaterialShaderRefs(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(materialShaderRefs, Is.Not.Null);
    }

    [Test]
    public void ListMaterialTextureRefs()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var materialTextureRefs = AssetBundleTools.ListMaterialTextureRefs(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(materialTextureRefs, Is.Not.Null);
    }

    [Test]
    public void ListPotentialDuplicates()
    {
        var assetBundleService = CreateAssetBundleService();
        
        AssetBundleTools.LoadAssetBundle(assetBundleService, AssetBundleDirPath);
        var potentialDuplicates = AssetBundleTools.ListPotentialDuplicates(assetBundleService);
        AssetBundleTools.UnLoadAssetBundle(assetBundleService);

        Assert.That(potentialDuplicates, Is.Not.Null);
    }
    
    private static AssetBundleService CreateAssetBundleService()
    {
        var repository = new AssetRepository();
        var analyzerService = new AnalyzerService();
        return new AssetBundleService(repository, analyzerService);
    }
}
