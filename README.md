# AssetBundleMCP

[日本語](README_JA.md)

`AssetBundleMCP` is an MCP (Model-Context-Protocol) server for easily and efficiently analyzing Unity AssetBundles through conversations with AI assistants (such as gemini-cli).

With this tool, developers and QA engineers can quickly obtain information such as a list of assets or texture details included in an AssetBundle simply by asking questions in natural language.

![Screenshot](docs/sample_english.png)

## Main Features

- **Interactive AssetBundle Analysis**: Analyze AssetBundles just by talking to your AI assistant.
- **Easy Installation**: Provided as a NuGet package, so you can easily introduce it by adding it to your configuration file.
- **Flexible Data Access**: You can also write SQL queries directly to the AI and freely extract information from the database-formatted analysis results.

## Prerequisites

- .NET 9.0 SDK or later

## Installation & Setup

### If .NET 10 is installed (Recommended)

### For .NET 10 preview6 or earlier (Not recommended)

1.  **Clone the repository**:  
    Clone with submodules using the `--recurse-submodules` option.
    ```bash
    git clone --recurse-submodules https://github.com/hanachiru/AssetBundleMCP.git
    cd AssetBundleMCP
    ```

2.  **Build the project**:
    ```bash
    dotnet build -c Release
    ```

3.  **Configure the MCP server**:  
    Create a configuration file in your project root according to your IDE.

    - **For Visual Studio Code**: `.vscode/mcp.json`
    - **For Visual Studio**: `.mcp.json`

    ```json
    {
      "servers": {
        "AssetBundleMCP": {
          "type": "stdio",
          "command": "dnx",
          "args": [
            "AssetBundleMCP",
            "--version",
            "0.1.2",
            "--yes"
          ]
        }
      }
    }
    ```

    - **For Gemini Cli**: `.gemini/settings.json`

    ```json
    {
      "mcpServers": {
        "AssetBundleMCP": {
          "command": "dnx",
          "args": [
            "AssetBundleMCP",
            "--version",
            "0.1.2",
            "--yes"
          ]
        }
      }
    }
    ```

## Usage

1.  **Load AssetBundle**:  
    Open Copilot Chat in your IDE, specify the directory path containing the AssetBundle you want to analyze, and instruct it to load.
    > `@workspace /loadAssetBundle C:/path/to/your/assetbundles`

    The tool will analyze the AssetBundle and save the results to a temporary database file.

2.  **Retrieve Information**:  
    Once loading is complete, you can ask various questions.
    - Get a list of assets:  
      > `@workspace /listAssets`
    - Get a list of textures:  
      > `@workspace /listTextures`
    - Find potentially duplicated assets:  
      > `@workspace /listPotentialDuplicates`
    - Execute a direct SQL query:  
      > `@workspace /executeSqlQuery SELECT * FROM assets WHERE size > 100000`

3.  **Finish Analysis**:  
    When analysis is complete, unload the database and release resources with the following command:
    > `@workspace /unLoadAssetBundle`

## Available Tools

| Command Name | Description |
| --- | --- |
| `LoadAssetBundle` | Loads an AssetBundle for analysis. |
| `UnLoadAssetBundle` | Unloads the loaded database file. |
| `ListAnimations` | Lists all animations in the AssetBundle. |
| `ListAssetDependencies` | Lists all asset dependencies in the AssetBundle. |
| `ListAssets` | Lists all assets in the AssetBundle. |
| `ListAudioClips` | Lists all audio clips in the AssetBundle. |
| `ListMeshes` | Lists all meshes in the AssetBundle. |
| `ListObjects` | Lists all objects in the AssetBundle. |
| `ListShaderKeywordRatios` | Lists all shader keyword ratios in the AssetBundle. |
| `ListShaderSubprograms` | Lists all shader subprograms in the AssetBundle. |
| `ListShaders` | Lists all shaders in the AssetBundle. |
| `ListTextures` | Lists all textures in the AssetBundle. |
| `ListBreakdownByType` | Lists breakdown by type in the AssetBundle. |
| `ListBreakdownShaders` | Lists breakdown of shaders in the AssetBundle. |
| `ListMaterialShaderRefs` | Lists all material shader references in the AssetBundle. |
| `ListMaterialTextureRefs` | Lists all material texture references in the AssetBundle. |
| `ListPotentialDuplicates` | Lists all potential duplicates in the AssetBundle. |
| `ExecuteSqlQuery` | Executes a SQL query on the AssetBundle database. |

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgements

The core analysis functionality of this tool uses [UnityDataTools](https://github.com/AssetTools/UnityDataTools). Many thanks to the developers of this excellent library.
