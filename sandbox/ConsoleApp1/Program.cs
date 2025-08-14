using System.Text.Json;
using AssetBundleMcpServer.Repository;
using AssetBundleMcpServer.Tool;
using Cocona;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Information);
});
builder.Services.AddSingleton<IAssetRepository, AssetRepository>();

var app = builder.Build();

app.AddCommand("list-animations", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var animations = AssetBundleTools.ListAnimations(repository, offset, pageSize);
    foreach (var animation in animations)
    {
        logger.LogInformation(JsonSerializer.Serialize(animation));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-asset-dependencies", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var dependencies = AssetBundleTools.ListAssetDependencies(repository, offset, pageSize);
    foreach (var dependency in dependencies)
    {
        logger.LogInformation(JsonSerializer.Serialize(dependency));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-assets", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var assets = AssetBundleTools.ListAssets(repository, offset, pageSize);
    foreach (var asset in assets)
    {
        logger.LogInformation(JsonSerializer.Serialize(asset));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-audio-clips", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var audioClips = AssetBundleTools.ListAudioClips(repository, offset, pageSize);
    foreach (var audioClip in audioClips)
    {
        logger.LogInformation(JsonSerializer.Serialize(audioClip));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-meshes", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var meshes = AssetBundleTools.ListMeshes(repository, offset, pageSize);
    foreach (var mesh in meshes)
    {
        logger.LogInformation(JsonSerializer.Serialize(mesh));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-objects", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var objects = AssetBundleTools.ListObjects(repository, offset, pageSize);
    foreach (var obj in objects)
    {
        logger.LogInformation(JsonSerializer.Serialize(obj));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-shader-keyword-ratios", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var shaderKeywordRatios = AssetBundleTools.ListShaderKeywordRatios(repository, offset, pageSize);
    foreach (var ratio in shaderKeywordRatios)
    {
        logger.LogInformation(JsonSerializer.Serialize(ratio));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-shader-subprograms", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var shaderSubprograms = AssetBundleTools.ListShaderSubprograms(repository, offset, pageSize);
    foreach (var subprogram in shaderSubprograms)
    {
        logger.LogInformation(JsonSerializer.Serialize(subprogram));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-shaders", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var shaders = AssetBundleTools.ListShaders(repository, offset, pageSize);
    foreach (var shader in shaders)
    {
        logger.LogInformation(JsonSerializer.Serialize(shader));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-textures", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var textures = AssetBundleTools.ListTextures(repository, offset, pageSize);
    foreach (var texture in textures)
    {
        logger.LogInformation(JsonSerializer.Serialize(texture));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-breakdown-by-type", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var breakdown = AssetBundleTools.ListBreakdownByType(repository, offset, pageSize);
    foreach (var item in breakdown)
    {
        logger.LogInformation(JsonSerializer.Serialize(item));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-breakdown-shaders", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var breakdownShaders = AssetBundleTools.ListBreakdownShaders(repository, offset, pageSize);
    foreach (var item in breakdownShaders)
    {
        logger.LogInformation(JsonSerializer.Serialize(item));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-material-shader-refs", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var materialShaderRefs = AssetBundleTools.ListMaterialShaderRefs(repository, offset, pageSize);
    foreach (var refItem in materialShaderRefs)
    {
        logger.LogInformation(JsonSerializer.Serialize(refItem));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-material-texture-refs", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var materialTextureRefs = AssetBundleTools.ListMaterialTextureRefs(repository, offset, pageSize);
    foreach (var refItem in materialTextureRefs)
    {
        logger.LogInformation(JsonSerializer.Serialize(refItem));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.AddCommand("list-potential-duplicates", (
    ILogger<Program> logger,
    IAssetRepository repository,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(assetBundleDir, databasePath);
    
    var potentialDuplicates = AssetBundleTools.ListPotentialDuplicates(repository, offset, pageSize);
    foreach (var duplicate in potentialDuplicates)
    {
        logger.LogInformation(JsonSerializer.Serialize(duplicate));
    }

    AssetBundleTools.UnLoadAssetBundle();
});

app.Run();