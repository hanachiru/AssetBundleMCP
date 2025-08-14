# AssetBundleMCP - AIアシスタントとの対話でUnity AssetBundleを分析するツール

`AssetBundleMCP`は、AIアシスタント（GitHub Copilot Chatなど）との対話を通じて、UnityのAssetBundleを簡単かつ効率的に分析するためのMCP (Model-Context-Protocol) サーバーです。

従来、AssetBundleの分析は専門的な知識や複数のツールを必要とする複雑な作業でした。このツールを使用することで、開発者やQAエンジニアは自然言語で質問するだけで、AssetBundleの内容、依存関係、潜在的な問題点などを迅速に把握できます。

## プレビュー

*ここにツールの使用例を示すスクリーンショットやGIFを挿入すると、より分かりやすくなります。*

![動作プレビュー](https://example.com/path/to/preview.gif)

## 主な機能

- **対話的なAssetBundle分析**: AIアシスタントに話しかけるだけで、AssetBundleを分析できます。
- **詳細な情報取得**: アセット、オブジェクト、テクスチャ、シェーダー、アニメーションなど、内部の各要素を一覧表示します。
- **依存関係の可視化**: アセット間の依存関係や、マテリアルとシェーダー/テクスチャの関連を明らかにします。
- **サイズの最適化支援**: タイプ別の内訳や、重複している可能性のあるアセットを検出し、最適化のヒントを得られます。
- **柔軟なデータアクセス**: 直接SQLクエリを実行し、データベース化された分析結果から自由に情報を抽出できます。

## 前提条件

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/ja/) または [Visual Studio Code](https://code.visualstudio.com/)
- [GitHub Copilot](https://github.com/features/copilot) 拡張機能

## インストールと設定

1.  **リポジトリのクローン**:
    Gitのサブモジュールも同時に取得するため、`--recurse-submodules` オプションを付けてクローンします。
    ```bash
    git clone --recurse-submodules https://github.com/your-username/AssetBundleMCP.git
    cd AssetBundleMCP
    ```

2.  **プロジェクトのビルド**:
    ```bash
    dotnet build -c Release
    ```

3.  **MCPサーバーの設定**:
    お使いのIDEに合わせて、プロジェクトのルートに設定ファイルを作成します。

    - **Visual Studio Code の場合**: `.vscode/mcp.json`
    - **Visual Studio の場合**: `.mcp.json`

    以下の内容でファイルを作成し、`<PATH TO PROJECT DIRECTORY>` を実際のプロジェクトディレクトリへの絶対パスに置き換えてください。

    ```json
    {
      "servers": {
        "AssetBundleMCP": {
          "type": "stdio",
          "command": "dotnet",
          "args": [
            "run",
            "--project",
            "<PATH TO PROJECT DIRECTORY>\src\AssetBundleMCP\AssetBundleMCP.csproj"
          ]
        }
      }
    }
    ```

## 使用方法

1.  **AssetBundleのロード**:
    IDEでCopilot Chatを開き、分析したいAssetBundleが含まれるディレクトリのパスを指定して、ロードを指示します。
    > `@workspace /loadAssetBundle C:/path/to/your/assetbundles`

    ツールがAssetBundleを分析し、結果を一時的なデータベースファイルに保存します。

2.  **情報の取得**:
    ロードが完了したら、様々な質問をすることができます。
    - アセットの一覧を取得する:
      > `@workspace /listAssets`
    - テクスチャの一覧を取得する:
      > `@workspace /listTextures`
    - 重複している可能性のあるアセットを探す:
      > `@workspace /listPotentialDuplicates`
    - SQLで直接クエリを実行する:
      > `@workspace /executeSqlQuery SELECT * FROM assets WHERE size > 100000`

3.  **分析の終了**:
    分析が終わったら、以下のコマンドでデータベースをアンロードし、リソースを解放します。
    > `@workspace /unLoadAssetBundle`

## 利用可能なツール一覧

| コマンド名 | 説明 |
| --- | --- |
| `LoadAssetBundle` | AssetBundleを分析のためにロードします。 |
| `UnLoadAssetBundle` | ロードしたデータベースファイルをアンロードします。 |
| `ListAnimations` | AssetBundle内のすべてのアニメーションを一覧表示します。 |
| `ListAssetDependencies` | AssetBundle内のすべてのアセットの依存関係を一覧表示します。 |
| `ListAssets` | AssetBundle内のすべてのアセットを一覧表示します。 |
| `ListAudioClips` | AssetBundle内のすべてのオーディオクリップを一覧表示します。 |
| `ListMeshes` | AssetBundle内のすべてのメッシュを一覧表示します。 |
| `ListObjects` | AssetBundle内のすべてのオブジェクトを一覧表示します。 |
| `ListShaderKeywordRatios` | AssetBundle内のすべてのシェーダーキーワードの比率を一覧表示します。 |
| `ListShaderSubprograms` | AssetBundle内のすべてのシェーダーサブプログラムを一覧表示します。 |
| `ListShaders` | AssetBundle内のすべてのシェーダーを一覧表示します。 |
| `ListTextures` | AssetBundle内のすべてのテクスチャを一覧表示します。 |
| `ListBreakdownByType` | AssetBundle内の内訳をタイプ別に一覧表示します。 |
| `ListBreakdownShaders` | AssetBundle内のシェーダーの内訳を一覧表示します。 |
| `ListMaterialShaderRefs` | AssetBundle内のすべてのマテリアルのシェーダー参照を一覧表示します。 |
| `ListMaterialTextureRefs` | AssetBundle内のすべてのマテリアルのテクスチャ参照を一覧表示します。 |
| `ListPotentialDuplicates` | AssetBundle内の重複の可能性があるものをすべて一覧表示します。 |
| `ExecuteSqlQuery` | AssetBundleデータベースに対してSQLクエリを実行します。 |

## ライセンス

このプロジェクトは [MIT License](LICENSE) の下で公開されています。

## 謝辞

このツールのコアな分析機能は [UnityDataTools](https://github.com/AssetTools/UnityDataTools) を利用しています。素晴らしいライブラリの開発者に感謝します。
