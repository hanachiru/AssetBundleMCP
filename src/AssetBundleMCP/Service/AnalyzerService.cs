using ModelContextProtocol;
using UnityDataTools.Analyzer;
using UnityDataTools.FileSystem;

namespace AssetBundleMcp.Service;

public class AnalyzerService : IAnalyzerService
{
    private readonly AnalyzerTool _analyzerTool = new();
    
    public string Analyze(string assetBundlePath, string? databaseFilePath = null)
    {
        if (!Directory.Exists(assetBundlePath) && !File.Exists(assetBundlePath))
        {
            throw new McpException($"Failed to load AssetBundle. Directory or File does not exist: {assetBundlePath}");
        }
        var isFile = File.Exists(assetBundlePath);

        try
        {
            UnityFileSystem.Init();
            
            databaseFilePath ??= Path.Combine(Directory.GetCurrentDirectory(), $"{Guid.NewGuid()}.db");
            var result = _analyzerTool.Analyze(
                isFile ? Directory.GetParent(assetBundlePath)!.FullName : assetBundlePath,
                databaseFilePath,
                isFile ? Path.GetFileNameWithoutExtension(assetBundlePath) : "*",
                false,
                false,
                false
            );

            if (result != 0)
            {
                throw new McpException(
                    "[ERROR] Failed to analyze AssetBundle. Please check the logs for more details.");
            }

            return databaseFilePath;
        }
        catch (Exception ex)
        {
            throw new McpException($"[ERROR] Failed to parse AssetBundle: {ex.Message}");
        }
    }
    
    public void Unload(string databaseFilePath)
    {
        if (File.Exists(databaseFilePath))
        {
            try
            {
                File.Delete(databaseFilePath);
            }
            catch (Exception ex)
            {
                throw new McpException($"[ERROR] Failed to unload AssetBundle: {ex.Message}");
            }
        }
    }
}
