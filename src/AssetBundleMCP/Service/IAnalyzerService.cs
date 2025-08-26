namespace AssetBundleMcp.Service;

public interface IAnalyzerService
{
    string Analyze(string assetBundlePath, string? databaseFilePath = null);

    public void Unload(string databaseFilePath);
}
