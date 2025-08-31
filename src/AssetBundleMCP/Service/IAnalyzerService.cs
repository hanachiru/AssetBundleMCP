namespace AssetBundleMcp.Service;

public interface IAnalyzerService
{
    string Analyze(string assetBundlePath, string? databaseFilePath = null);
    void Unload(string databaseFilePath);
}
