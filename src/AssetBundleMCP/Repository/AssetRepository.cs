
using System.Text;
using AssetBundleMcpServer.Entity;
using Microsoft.Data.Sqlite;
using Object = AssetBundleMcpServer.Entity.Object;

namespace AssetBundleMcpServer.Repository;

public class AssetRepository : IAssetRepository, IDisposable
{
    private static string CreateConnectionString(string dbPath)
    {
        return $"Data Source={dbPath}";
    }

    public Animation[] GetAnimations(string dbPath)
    {
        var animations = new List<Animation>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT id, object_id, asset_bundle, serialized_file, type, name, game_object, size, pretty_size, crc32, legacy, events FROM animation_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var animation = new Animation
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                ObjectId = reader.GetInt64(reader.GetOrdinal("object_id")),
                AssetBundle = reader.GetString(reader.GetOrdinal("asset_bundle")),
                SerializedFile = reader.GetString(reader.GetOrdinal("serialized_file")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                GameObject = reader.GetInt64(reader.GetOrdinal("game_object")),
                Size = reader.GetInt64(reader.GetOrdinal("size")),
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B",
                Crc32 = reader.GetInt64(reader.GetOrdinal("crc32")),
                Legacy = reader.GetInt64(reader.GetOrdinal("legacy")),
                Events = reader.GetInt64(reader.GetOrdinal("events"))
            };
            animations.Add(animation);
        }

        return animations.OrderBy(animation => animation.Id).ToArray();
    }

    public AssetDependencies[] GetAssetDependencies(string dbPath)
    {
        var dependencies = new List<AssetDependencies>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT id, asset_name, asset_bundle, type, dep_id, dep_asset_bundle, dep_name, dep_type FROM asset_dependencies_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var dependency = new AssetDependencies
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                AssetName = reader.GetString(reader.GetOrdinal("asset_name")),
                AssetBundle = reader.GetString(reader.GetOrdinal("asset_bundle")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                DepId = reader.GetInt64(reader.GetOrdinal("dep_id")),
                DepAssetBundle = reader.GetString(reader.GetOrdinal("dep_asset_bundle")),
                DepName = reader.GetString(reader.GetOrdinal("dep_name")),
                DepType = reader.GetString(reader.GetOrdinal("dep_type"))
            };
            dependencies.Add(dependency);
        }

        return dependencies.OrderBy(dep => dep.Id).ToArray();
    }

    public Asset[] GetAssets(string dbPath)
    {
        var assets = new List<Asset>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT asset_name, id, object_id, asset_bundle, serialized_file, type, name, game_object, size, pretty_size, crc32 FROM asset_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var asset = new Asset
            {
                AssetName = reader.GetString(reader.GetOrdinal("asset_name")),
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                ObjectId = reader.GetInt64(reader.GetOrdinal("object_id")),
                AssetBundle = reader.GetString(reader.GetOrdinal("asset_bundle")),
                SerializedFile = reader.GetString(reader.GetOrdinal("serialized_file")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                GameObject = reader.GetInt64(reader.GetOrdinal("game_object")),
                Size = reader.GetInt64(reader.GetOrdinal("size")),
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B",
                Crc32 = reader.GetInt64(reader.GetOrdinal("crc32"))
            };
            assets.Add(asset);
        }

        return assets.OrderBy(asset => asset.Id).ToArray();
    }

    public AudioClip[] GetAudioClips(string dbPath)
    {
        var audioClips = new List<AudioClip>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT id, object_id, asset_bundle, serialized_file, type, name, game_object, size, pretty_size, crc32, bits_per_sample, frequency, channels, load_type, format FROM audio_clip_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var audioClip = new AudioClip
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                ObjectId = reader.GetInt64(reader.GetOrdinal("object_id")),
                AssetBundle = reader.GetString(reader.GetOrdinal("asset_bundle")),
                SerializedFile = reader.GetString(reader.GetOrdinal("serialized_file")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                GameObject = reader.GetInt64(reader.GetOrdinal("game_object")),
                Size = reader.GetInt64(reader.GetOrdinal("size")),
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B",
                Crc32 = reader.GetInt64(reader.GetOrdinal("crc32")),
                BitsPerSample = reader.GetInt64(reader.GetOrdinal("bits_per_sample")),
                Frequency = reader.GetInt64(reader.GetOrdinal("frequency")),
                Channels = reader.GetInt64(reader.GetOrdinal("channels")),
                LoadType = reader.GetString(reader.GetOrdinal("load_type")),
                Format = reader.GetString(reader.GetOrdinal("format"))
            };
            audioClips.Add(audioClip);
        }

        return audioClips.OrderBy(clip => clip.Id).ToArray();
    }

    public Mesh[] GetMeshes(string dbPath)
    {
        var meshes = new List<Mesh>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT id, object_id, asset_bundle, serialized_file, type, name, game_object, size, pretty_size, crc32, sub_meshes, blend_shapes, bones, indices, vertices, compression, rw_enabled, vertex_size, channels FROM mesh_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var mesh = new Mesh
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                ObjectId = reader.GetInt64(reader.GetOrdinal("object_id")),
                AssetBundle = reader.GetString(reader.GetOrdinal("asset_bundle")),
                SerializedFile = reader.GetString(reader.GetOrdinal("serialized_file")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                GameObject = reader.GetInt64(reader.GetOrdinal("game_object")),
                Size = reader.GetInt64(reader.GetOrdinal("size")),
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B",
                Crc32 = reader.GetInt64(reader.GetOrdinal("crc32")),
                SubMeshes = reader.GetInt64(reader.GetOrdinal("sub_meshes")),
                BlendShapes = reader.GetInt64(reader.GetOrdinal("blend_shapes")),
                Bones = reader.GetInt64(reader.GetOrdinal("bones")),
                Indices = reader.GetInt64(reader.GetOrdinal("indices")),
                Vertices = reader.GetInt64(reader.GetOrdinal("vertices")),
                Compression = reader.GetInt64(reader.GetOrdinal("compression")),
                RwEnabled = reader.GetInt64(reader.GetOrdinal("rw_enabled")),
                VertexSize = reader.GetInt64(reader.GetOrdinal("vertex_size")),
                Channels = reader.IsDBNull(reader.GetOrdinal("channels"))
                    ? string.Empty
                    : reader.GetString(reader.GetOrdinal("channels"))
            };
            meshes.Add(mesh);
        }

        return meshes.OrderBy(mesh => mesh.Id).ToArray();
    }

    public Object[] GetObjects(string dbPath)
    {
        var objects = new List<Object>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT id, object_id, asset_bundle, serialized_file, type, name, game_object, size, pretty_size, crc32 FROM object_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var obj = new Object
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                ObjectId = reader.GetInt64(reader.GetOrdinal("object_id")),
                AssetBundle = reader.GetString(reader.GetOrdinal("asset_bundle")),
                SerializedFile = reader.GetString(reader.GetOrdinal("serialized_file")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                GameObject = reader.GetInt64(reader.GetOrdinal("game_object")),
                Size = reader.GetInt64(reader.GetOrdinal("size")),
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B",
                Crc32 = reader.GetInt64(reader.GetOrdinal("crc32"))
            };
            objects.Add(obj);
        }

        return objects.OrderBy(obj => obj.Id).ToArray();
    }

    public ShaderKeywordRatio[] GetShaderKeywordRatios(string dbPath)
    {
        var shaderKeywordRatios = new List<ShaderKeywordRatio>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT shader_id, name, sub_shader, hw_tier, pass, api, pass_name, shader_type, total_variants, keyword, variants, ratio FROM shader_keyword_ratios";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var ratio = new ShaderKeywordRatio
            {
                ShaderId = reader.GetInt64(reader.GetOrdinal("shader_id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                SubShader = reader.GetInt64(reader.GetOrdinal("sub_shader")),
                HwTier = reader.GetInt64(reader.GetOrdinal("hw_tier")),
                Pass = reader.GetInt64(reader.GetOrdinal("pass")),
                Api = reader.GetString(reader.GetOrdinal("api")),
                PassName = reader.GetString(reader.GetOrdinal("pass_name")),
                ShaderType = reader.GetString(reader.GetOrdinal("shader_type")),
                TotalVariants = reader.GetValue(reader.GetOrdinal("total_variants")).ToString() ?? "",
                Keyword = reader.GetString(reader.GetOrdinal("keyword")),
                Variants = reader.GetValue(reader.GetOrdinal("variants")).ToString() ?? "",
                Ratio = reader.GetValue(reader.GetOrdinal("ratio")).ToString() ?? ""
            };
            shaderKeywordRatios.Add(ratio);
        }

        return shaderKeywordRatios.OrderBy(r => r.ShaderId).ToArray();
    }

    public ShaderSubprogram[] GetShaderSubprograms(string dbPath)
    {
        var shaderSubprograms = new List<ShaderSubprogram>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT shader_id, name, sub_shader, hw_tier, api, pass, pass_name, shader_type, sub_program, keywords FROM shader_subprogram_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var subprogram = new ShaderSubprogram
            {
                ShaderId = reader.GetInt64(reader.GetOrdinal("shader_id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                SubShader = reader.GetInt64(reader.GetOrdinal("sub_shader")),
                HwTier = reader.GetInt64(reader.GetOrdinal("hw_tier")),
                Api = reader.GetString(reader.GetOrdinal("api")),
                Pass = reader.GetInt64(reader.GetOrdinal("pass")),
                PassName = reader.GetString(reader.GetOrdinal("pass_name")),
                ShaderType = reader.GetString(reader.GetOrdinal("shader_type")),
                SubProgram = reader.GetInt64(reader.GetOrdinal("sub_program")),
                Keywords = reader.GetValue(reader.GetOrdinal("keywords")).ToString() ?? ""
            };
            shaderSubprograms.Add(subprogram);
        }

        return shaderSubprograms.OrderBy(sp => sp.ShaderId).ToArray();
    }

    public Shader[] GetShaders(string dbPath)
    {
        var shaders = new List<Shader>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT id, object_id, asset_bundle, serialized_file, type, name, game_object, size, pretty_size, crc32, decompressed_size, sub_shaders, sub_programs, unique_programs, keywords FROM shader_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var shader = new Shader
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                ObjectId = reader.GetInt64(reader.GetOrdinal("object_id")),
                AssetBundle = reader.GetString(reader.GetOrdinal("asset_bundle")),
                SerializedFile = reader.GetString(reader.GetOrdinal("serialized_file")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                GameObject = reader.GetInt64(reader.GetOrdinal("game_object")),
                Size = reader.GetInt64(reader.GetOrdinal("size")),
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B",
                Crc32 = reader.GetInt64(reader.GetOrdinal("crc32")),
                DecompressedSize = reader.GetInt64(reader.GetOrdinal("decompressed_size")),
                SubShaders = reader.GetValue(reader.GetOrdinal("sub_shaders")).ToString() ?? "",
                SubPrograms = reader.GetValue(reader.GetOrdinal("sub_programs")).ToString() ?? "",
                UniquePrograms = reader.GetInt64(reader.GetOrdinal("unique_programs")),
                Keywords = reader.GetValue(reader.GetOrdinal("keywords")).ToString() ?? ""
            };
            shaders.Add(shader);
        }

        return shaders.OrderBy(shader => shader.Id).ToArray();
    }

    public Texture[] GetTextures(string dbPath)
    {
        var textures = new List<Texture>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT id, object_id, asset_bundle, serialized_file, type, name, game_object, size, pretty_size, crc32, width, height, format, mip_count, rw_enabled FROM texture_view";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var texture = new Texture
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                ObjectId = reader.GetInt64(reader.GetOrdinal("object_id")),
                AssetBundle = reader.GetString(reader.GetOrdinal("asset_bundle")),
                SerializedFile = reader.GetString(reader.GetOrdinal("serialized_file")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                GameObject = reader.GetInt64(reader.GetOrdinal("game_object")),
                Size = reader.GetInt64(reader.GetOrdinal("size")),
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B",
                Crc32 = reader.GetInt64(reader.GetOrdinal("crc32")),
                Width = reader.GetInt64(reader.GetOrdinal("width")),
                Height = reader.GetInt64(reader.GetOrdinal("height")),
                Format = reader.GetString(reader.GetOrdinal("format")),
                MipCount = reader.GetInt64(reader.GetOrdinal("mip_count")),
                RwEnabled = reader.GetInt64(reader.GetOrdinal("rw_enabled"))
            };
            textures.Add(texture);
        }

        return textures.OrderBy(texture => texture.Id).ToArray();
    }

    public BreakdownByType[] GetBreakdownByType(string dbPath)
    {
        var breakdowns = new List<BreakdownByType>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT type, count, byte_size, pretty_size FROM view_breakdown_by_type";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var breakdown = new BreakdownByType
            {
                Type = reader.GetString(reader.GetOrdinal("type")),
                Count = reader.GetValue(reader.GetOrdinal("count")).ToString() ?? "0",
                ByteSize = reader.GetValue(reader.GetOrdinal("byte_size")).ToString() ?? "0",
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B"
            };
            breakdowns.Add(breakdown);
        }

        return breakdowns.OrderBy(b => b.Type).ToArray();
    }

    public BreakdownShaders[] GetBreakdownShaders(string dbPath)
    {
        var breakdowns = new List<BreakdownShaders>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT name, instances, pretty_total_size, total_size, in_bundles FROM view_breakdown_shaders";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var breakdown = new BreakdownShaders
            {
                Name = reader.GetString(reader.GetOrdinal("name")),
                Instances = reader.GetValue(reader.GetOrdinal("instances")).ToString() ?? "0",
                PrettyTotalSize = reader.GetValue(reader.GetOrdinal("pretty_total_size")).ToString() ?? "0B",
                TotalSize = reader.GetValue(reader.GetOrdinal("total_size")).ToString() ?? "0",
                InBundles = reader.GetValue(reader.GetOrdinal("in_bundles")).ToString() ?? "0"
            };
            breakdowns.Add(breakdown);
        }

        return breakdowns.OrderBy(b => b.Name).ToArray();
    }

    public MaterialShaderRefs[] GetMaterialShaderRefs(string dbPath)
    {
        var materialShaderRefs = new List<MaterialShaderRefs>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT material_id, material_name, material_path, material_asset_bundle, shader_id, shader_name, shader_asset_bundle FROM view_material_shader_refs";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var refItem = new MaterialShaderRefs
            {
                MaterialId = reader.GetInt64(reader.GetOrdinal("material_id")),
                MaterialName = reader.GetString(reader.GetOrdinal("material_name")),
                MaterialPath = reader.GetString(reader.GetOrdinal("material_path")),
                MaterialAssetBundle = reader.GetString(reader.GetOrdinal("material_asset_bundle")),
                ShaderId = reader.GetInt64(reader.GetOrdinal("shader_id")),
                ShaderName = reader.GetString(reader.GetOrdinal("shader_name")),
                ShaderAssetBundle = reader.GetString(reader.GetOrdinal("shader_asset_bundle"))
            };
            materialShaderRefs.Add(refItem);
        }

        return materialShaderRefs.OrderBy(m => m.MaterialId).ToArray();
    }

    public MaterialTextureRefs[] GetMaterialTextureRefs(string dbPath)
    {
        var materialTextureRefs = new List<MaterialTextureRefs>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT material_id, material_name, material_path, material_asset_bundle, texture_id, texture_name, texture_asset_bundle FROM view_material_texture_refs";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var refItem = new MaterialTextureRefs
            {
                MaterialId = reader.GetInt64(reader.GetOrdinal("material_id")),
                MaterialName = reader.GetString(reader.GetOrdinal("material_name")),
                MaterialPath = reader.GetString(reader.GetOrdinal("material_path")),
                MaterialAssetBundle = reader.GetString(reader.GetOrdinal("material_asset_bundle")),
                TextureId = reader.GetInt64(reader.GetOrdinal("texture_id")),
                TextureName = reader.GetString(reader.GetOrdinal("texture_name")),
                TextureAssetBundle = reader.GetString(reader.GetOrdinal("texture_asset_bundle"))
            };
            materialTextureRefs.Add(refItem);
        }

        return materialTextureRefs.OrderBy(m => m.MaterialId).ToArray();
    }

    public PotentialDuplicates[] GetPotentialDuplicates(string dbPath)
    {
        var potentialDuplicates = new List<PotentialDuplicates>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            "SELECT instances, name, type, pretty_total_size, total_size, size, pretty_size, in_files FROM view_potential_duplicates";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var duplicate = new PotentialDuplicates
            {
                Instances = reader.GetValue(reader.GetOrdinal("instances")).ToString() ?? "0",
                Name = reader.GetString(reader.GetOrdinal("name")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                PrettyTotalSize = reader.GetValue(reader.GetOrdinal("pretty_total_size")).ToString() ?? "0B",
                TotalSize = reader.GetValue(reader.GetOrdinal("total_size")).ToString() ?? "0",
                Size = reader.GetInt64(reader.GetOrdinal("size")),
                PrettySize = reader.GetValue(reader.GetOrdinal("pretty_size")).ToString() ?? "0B",
                InFiles = reader.GetValue(reader.GetOrdinal("in_files")).ToString() ?? "0"
            };
            potentialDuplicates.Add(duplicate);
        }

        return potentialDuplicates.OrderBy(d => d.Name).ToArray();
    }

    public string[] ExecuteCustomQuery(string dbPath, string query)
    {
        var results = new List<string>();

        var connectionString = CreateConnectionString(dbPath);
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = query;

        using var reader = command.ExecuteReader();
        var builder = new StringBuilder();
        while (reader.Read())
        {
            builder.Append("{ ");
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (i > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"\"{reader.GetName(i)}\" : \"{reader.GetValue(i).ToString() ?? string.Empty}\"");
            }

            builder.Append(" }");
            results.Add(builder.ToString());
            builder.Clear();
        }

        return results.ToArray();
    }

    public void Dispose()
    {
        SqliteConnection.ClearAllPools();
    }
}