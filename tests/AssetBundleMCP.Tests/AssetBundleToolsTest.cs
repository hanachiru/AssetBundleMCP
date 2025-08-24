using AssetBundleMcpServer.Repository;
using AssetBundleMcpServer.Tool;

namespace AssetBundleMCP.Tests;

public class Tests
{
    private string AssetBundleDirPath => Path.Combine(AppContext.BaseDirectory, "TestData");

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        if (AssetBundleTools.IsLoaded())
        {
            AssetBundleTools.UnLoadAssetBundle();
        }
    }

    [Test]
    public void LoadAssetBundle()
    {
        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);

        Assert.That(AssetBundleTools.DatabasePath, Is.Not.Null);
    }
    
    [Test]
    public void ListAnimations()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var animations = AssetBundleTools.ListAnimations(repository);

        Assert.That(animations, Is.Not.Null);
    }

    [Test]
    public void ListAssetDependencies()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var dependencies = AssetBundleTools.ListAssetDependencies(repository);

        Assert.That(dependencies, Is.Not.Null);
    }

    [Test]
    public void ListAssets()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var assets = AssetBundleTools.ListAssets(repository);

        Assert.That(assets, Is.Not.Null);
    }

    [Test]
    public void ListAudioClips()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var audioClips = AssetBundleTools.ListAudioClips(repository);

        Assert.That(audioClips, Is.Not.Null);
    }

    [Test]
    public void ListMeshes()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var meshes = AssetBundleTools.ListMeshes(repository);

        Assert.That(meshes, Is.Not.Null);
    }

    [Test]
    public void ListObjects()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var objects = AssetBundleTools.ListObjects(repository);

        Assert.That(objects, Is.Not.Null);
    }

    [Test]
    public void ListShaderKeywordRatios()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var shaderKeywords = AssetBundleTools.ListShaderKeywordRatios(repository);

        Assert.That(shaderKeywords, Is.Not.Null);
    }

    [Test]
    public void ListShaderSubprograms()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var shaderSubprograms = AssetBundleTools.ListShaderSubprograms(repository);

        Assert.That(shaderSubprograms, Is.Not.Null);
    }

    [Test]
    public void ListShaders()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var shaders = AssetBundleTools.ListShaders(repository);

        Assert.That(shaders, Is.Not.Null);
    }

    [Test]
    public void ListTextures()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var textures = AssetBundleTools.ListTextures(repository);

        Assert.That(textures, Is.Not.Null);
    }

    [Test]
    public void BreakdownByType()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var breakdown = AssetBundleTools.ListBreakdownByType(repository);

        Assert.That(breakdown, Is.Not.Null);
    }

    [Test]
    public void BreakdownShaders()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var breakdownShaders = AssetBundleTools.ListBreakdownShaders(repository);

        Assert.That(breakdownShaders, Is.Not.Null);
    }

    [Test]
    public void ListMaterialShaderRefs()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var materialShaderRefs = AssetBundleTools.ListMaterialShaderRefs(repository);

        Assert.That(materialShaderRefs, Is.Not.Null);
    }

    [Test]
    public void ListMaterialTextureRefs()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var materialTextureRefs = AssetBundleTools.ListMaterialTextureRefs(repository);

        Assert.That(materialTextureRefs, Is.Not.Null);
    }

    [Test]
    public void ListPotentialDuplicates()
    {
        var repository = new AssetRepository();

        AssetBundleTools.LoadAssetBundle(AssetBundleDirPath);
        var potentialDuplicates = AssetBundleTools.ListPotentialDuplicates(repository);

        Assert.That(potentialDuplicates, Is.Not.Null);
    }
}