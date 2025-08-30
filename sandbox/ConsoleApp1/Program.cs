using System.Text.Json;
using AssetBundleMcp.Repository;
using AssetBundleMcp.Service;
using AssetBundleMcp.Tool;
using Cocona;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Information);
});
builder.Services.AddScoped<IAssetBundleService, AssetBundleService>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddSingleton<IAnalyzerService, AnalyzerService>();

var app = builder.Build();

app.AddCommand("list-animations", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);
    
    var animations = AssetBundleTools.ListAnimations(service, offset, pageSize);
    foreach (var animation in animations)
    {
        logger.LogInformation(JsonSerializer.Serialize(animation));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-asset-dependencies", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);
    
    var dependencies = AssetBundleTools.ListAssetDependencies(service, offset, pageSize);
    foreach (var dependency in dependencies)
    {
        logger.LogInformation(JsonSerializer.Serialize(dependency));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-assets", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);
    
    var assets = AssetBundleTools.ListAssets(service, offset, pageSize);
    foreach (var asset in assets)
    {
        logger.LogInformation(JsonSerializer.Serialize(asset));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-audio-clips", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var audioClips = AssetBundleTools.ListAudioClips(service, offset, pageSize);
    foreach (var audioClip in audioClips)
    {
        logger.LogInformation(JsonSerializer.Serialize(audioClip));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-meshes", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var meshes = AssetBundleTools.ListMeshes(service, offset, pageSize);
    foreach (var mesh in meshes)
    {
        logger.LogInformation(JsonSerializer.Serialize(mesh));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-objects", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var objects = AssetBundleTools.ListObjects(service, offset, pageSize);
    foreach (var obj in objects)
    {
        logger.LogInformation(JsonSerializer.Serialize(obj));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-shader-keyword-ratios", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var shaderKeywordRatios = AssetBundleTools.ListShaderKeywordRatios(service, offset, pageSize);
    foreach (var ratio in shaderKeywordRatios)
    {
        logger.LogInformation(JsonSerializer.Serialize(ratio));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-shader-subprograms", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var shaderSubprograms = AssetBundleTools.ListShaderSubprograms(service, offset, pageSize);
    foreach (var subprogram in shaderSubprograms)
    {
        logger.LogInformation(JsonSerializer.Serialize(subprogram));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-shaders", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var shaders = AssetBundleTools.ListShaders(service, offset, pageSize);
    foreach (var shader in shaders)
    {
        logger.LogInformation(JsonSerializer.Serialize(shader));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-textures", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var textures = AssetBundleTools.ListTextures(service, offset, pageSize);
    foreach (var texture in textures)
    {
        logger.LogInformation(JsonSerializer.Serialize(texture));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-breakdown-by-type", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var breakdown = AssetBundleTools.ListBreakdownByType(service, offset, pageSize);
    foreach (var item in breakdown)
    {
        logger.LogInformation(JsonSerializer.Serialize(item));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-breakdown-shaders", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var breakdownShaders = AssetBundleTools.ListBreakdownShaders(service, offset, pageSize);
    foreach (var item in breakdownShaders)
    {
        logger.LogInformation(JsonSerializer.Serialize(item));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-material-shader-refs", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var materialShaderRefs = AssetBundleTools.ListMaterialShaderRefs(service, offset, pageSize);
    foreach (var refItem in materialShaderRefs)
    {
        logger.LogInformation(JsonSerializer.Serialize(refItem));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-material-texture-refs", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var materialTextureRefs = AssetBundleTools.ListMaterialTextureRefs(service, offset, pageSize);
    foreach (var refItem in materialTextureRefs)
    {
        logger.LogInformation(JsonSerializer.Serialize(refItem));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.AddCommand("list-potential-duplicates", (
    ILogger<Program> logger,
    IAssetBundleService service,
    [Argument]string assetBundleDir,
    [Option]string? databasePath = null,
    [Option]int offset = 0,
    [Option]int pageSize = 100
    ) =>
{
    AssetBundleTools.LoadAssetBundle(service, assetBundleDir, databasePath);

    var potentialDuplicates = AssetBundleTools.ListPotentialDuplicates(service, offset, pageSize);
    foreach (var duplicate in potentialDuplicates)
    {
        logger.LogInformation(JsonSerializer.Serialize(duplicate));
    }

    AssetBundleTools.UnLoadAssetBundle(service);
});

app.Run();