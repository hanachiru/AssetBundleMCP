using System.ComponentModel;
using ModelContextProtocol.Server;

namespace AssetBundleMCP.Resource;

[McpServerResourceType]
public class AssetBundleResources
{
    [McpServerResource(Name = "SQLite table structure", MimeType = "text/plain")]
    [Description("Retrieves the SQLite table structure resulting from AssetBundle analysis.")]
    public static string[] GetAssetBundleSchema()
    {
        return
        [
            """
            CREATE TABLE animation_clips(
                id INTEGER,
                legacy INTEGER,
                events INTEGER,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE asset_bundles
            (
                id INTEGER,
                name TEXT,
                file_size INTEGER,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE asset_dependencies(
                object INTEGER,
                dependency INTEGER
            )
            """,
            """
            CREATE TABLE assets(
                object INTEGER,
                name TEXT
            )
            """,
            """
            CREATE TABLE audio_clips(
                id INTEGER,
                bits_per_sample INTEGER,
                frequency INTEGER,
                channels INTEGER,
                load_type INTEGER,
                format INTEGER,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE audio_formats(
                id INTEGER,
                name TEXT,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE audio_load_types(
                id INTEGER,
                name TEXT,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE meshes(
                id INTEGER,
                sub_meshes INTEGER,
                blend_shapes INTEGER,
                bones INTEGER,
                indices INTEGER,
                vertices INTEGER,
                compression INTEGER,
                rw_enabled INTEGER,
                vertex_size INTEGER,
                channels TEXT,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE objects
            (
                id INTEGER,
                object_id INTEGER,
                serialized_file INTEGER,
                type INTEGER,
                name TEXT,
                game_object INTEGER,
                size INTEGER,
                crc32 INTEGER,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE refs
            (
                object INTEGER,
                referenced_object INTEGER,
                property_path TEXT,
                property_type TEXT
            )
            """,
            """
            CREATE TABLE serialized_files
            (
                id INTEGER,
                asset_bundle INTEGER,
                name TEXT,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE shader_apis(
                id INTEGER,
                name TEXT,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE shader_keywords(
                id INTEGER,
                keyword TEXT,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE shader_subprogram_keywords(
                subprogram_id INTEGER,
                keyword_id INTEGER
            )
            """,
            """
            CREATE TABLE shader_subprograms(
                id INTEGER,
                shader INTEGER,
                sub_shader INTEGER,
                pass INTEGER,
                pass_name TEXT,
                sub_program INTEGER,
                hw_tier INTEGER,
                shader_type TEXT,
                api INTEGER,
                PRIMARY KEY(id)
            )
            """,
            """
            CREATE TABLE shaders(
                id INTEGER,
                decompressed_size INTEGER,
                unique_programs INTEGER,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE texture_formats
            (
                id INTEGER,
                name TEXT,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE textures
            (
                id INTEGER,
                width INTEGER,
                height INTEGER,
                format INTEGER,
                mip_count INTEGER,
                rw_enabled INTEGER,
                PRIMARY KEY (id)
            )
            """,
            """
            CREATE TABLE types
            (
                id INTEGER,
                name TEXT,
                PRIMARY KEY (id)
            )
            """
        ];
    }

    [McpServerResource(Name = "Sample SQLite Queries", MimeType = "text/plain")]
    [Description("Get sample SQLite queries generated from AssetBundle analysis.")]
    public static string[] GetQuerySample()
    {
        return
        [
            """
            SELECT
                o.*,
                a.legacy,
                a.events
            FROM object_view o INNER JOIN animation_clips a ON o.id = a.id
            """,
            """
            SELECT a.id, a.asset_name, a.asset_bundle, a.type, od.id dep_id, od.asset_bundle dep_asset_bundle, od.name dep_name, od.type dep_type
            FROM asset_view a
            INNER JOIN asset_dependencies d ON a.id = d.object
            INNER JOIN object_view od ON od.id = d.dependency
            """,
            """
            SELECT
                a.name AS asset_name,
                o.*
            FROM assets a INNER JOIN object_view o ON o.id = a.object
            """,
            """
            SELECT
            	o.*,
            	a.bits_per_sample,
            	a.frequency,
            	a.channels,
            	l.name AS load_type,
            	f.name AS format
            FROM object_view o
            INNER JOIN audio_clips a ON o.id = a.id
            LEFT JOIN audio_load_types l ON a.load_type = l.id
            LEFT JOIN audio_formats f ON a.format = f.id
            """,
            """
            SELECT
                o.*,
                m.sub_meshes,
                m.blend_shapes,
                m.bones,
                m.indices,
                m.vertices,
                m.compression,
                m.rw_enabled,
                m.vertex_size,
                m.channels
            FROM meshes m
            INNER JOIN object_view o ON o.id = m.id
            """,
            """
            SELECT o.id, o.object_id, ab.name AS asset_bundle, sf.name AS serialized_file, t.name AS type, o.name, o.game_object, o.size,
            CASE
                WHEN size < 1024 THEN printf('%!5.1f B', size * 1.0)
                WHEN size >=  1024 AND size < (1024 * 1024) THEN printf('%!5.1f KB', size / 1024.0)
                WHEN size >= (1024 * 1024)  AND size < (1024 * 1024 * 1024) THEN printf('%!5.1f MB', size / 1024.0 / 1024)
                WHEN size >= (1024 * 1024 * 1024) THEN printf('%!5.1f GB', size / 1024.0 / 1024 / 1024)
            END AS pretty_size, o.crc32
            FROM objects o
            INNER JOIN types t ON o.type = t.id
            INNER JOIN serialized_files sf ON o.serialized_file = sf.id
            LEFT JOIN asset_bundles ab ON sf.asset_bundle = ab.id
            """,
            """
            SELECT t.shader_id, o.name, t.sub_shader, t.hw_tier, t.pass, api.name AS api, t.pass_name, t.shader_type, t.total_variants, k.keyword, t.variants, t.ratio
            FROM
            (
            	SELECT sp.shader AS shader_id, sp.sub_shader, sp.hw_tier, sp.api, sp.pass, sp.pass_name, sp.shader_type, sp.total_variants, sk.keyword_id,
            	COUNT(*) AS variants,
            	printf('%.3f', CAST(COUNT(*) AS FLOAT) / sp.total_variants) AS ratio
            	FROM
            	(
            		SELECT id, shader, sub_shader, hw_tier, api, pass, pass_name, shader_type,
            		COUNT(id) OVER(PARTITION BY shader, sub_shader, hw_tier, api, pass, shader_type) AS total_variants
            		FROM shader_subprograms
            	) sp
            	INNER JOIN shader_subprogram_keywords sk ON sk.subprogram_id = sp.id
            	GROUP BY shader_id, sp.sub_shader, sp.hw_tier, sp.api, sp.pass, sp.shader_type, sk.keyword_id
            	ORDER BY shader_id, sp.sub_shader, sp.hw_tier, sp.api, sp.pass, sp.shader_type, ratio DESC
            ) t
            CROSS JOIN objects o ON o.id = t.shader_id
            CROSS JOIN shader_apis api ON api.id = t.api
            CROSS JOIN shader_keywords k ON k.id = t.keyword_id
            """,
            """
            SELECT sp.shader AS shader_id, o.name, sp.sub_shader, sp.hw_tier, api.name api, sp.pass, sp.pass_name, sp.shader_type, sp.sub_program, GROUP_CONCAT(k.keyword, ',' || CHAR(13)) AS keywords
            FROM shader_subprograms sp
            CROSS JOIN objects o ON o.id = sp.shader
            CROSS JOIN shader_apis api ON api.id = sp.api
            LEFT JOIN shader_subprogram_keywords sk ON sk.subprogram_id = sp.id
            LEFT JOIN shader_keywords k ON sk.keyword_id = k.id
            GROUP BY sp.id
            """,
            """
            SELECT
                o.*,
                s.decompressed_size,
            	(SELECT MAX(sub_shader) FROM shader_subprograms sp WHERE s.id = sp.shader) + 1 AS sub_shaders,
                (SELECT COUNT(*) FROM shader_subprograms sp WHERE s.id = sp.shader) AS sub_programs,
                s.unique_programs,
                (
            		SELECT GROUP_CONCAT(k.keyword, ',' || CHAR(13)) FROM
            		(
            			SELECT DISTINCT kp.keyword_id FROM
            			shader_subprograms sp
            			INNER JOIN shader_subprogram_keywords kp ON sp.id = kp.subprogram_id
            			WHERE sp.shader = s.id
            		)
            		INNER JOIN shader_keywords k ON keyword_id = k.id
            	) AS keywords
            FROM object_view o
            INNER JOIN shaders s ON o.id = s.id
            """,
            """
            SELECT
                o.*,
                t.width,
                t.height,
                f.name AS format,
                t.mip_count,
                t.rw_enabled
            FROM object_view o
            INNER JOIN textures t ON o.id = t.id
            LEFT JOIN texture_formats f ON t.format = f.id
            """,
            """
            SELECT *,
            CASE
            	WHEN byte_size < 1024 THEN printf('%!5.1f B', byte_size * 1.0)
            	WHEN byte_size >=  1024 AND byte_size < (1024 * 1024) THEN printf('%!5.1f KB', byte_size / 1024.0)
            	WHEN byte_size >= (1024 * 1024)  AND byte_size < (1024 * 1024 * 1024) THEN printf('%!5.1f MB', byte_size / 1024.0 / 1024)
            	WHEN byte_size >= (1024 * 1024 * 1024) THEN printf('%!5.1f GB', byte_size / 1024.0 / 1024 / 1024)
            END AS pretty_size
            FROM
            (SELECT type, count(*) AS count, sum(size) AS byte_size
            FROM object_view AS o
            GROUP BY type
            ORDER BY byte_size DESC, count DESC)
            """,
            """
            SELECT name, count(*) AS instances,
            CASE
                WHEN sum(size) < 1024 THEN printf('%!5.1f B', sum(size) * 1.0)
                WHEN sum(size) >=  1024 AND sum(size) < (1024 * 1024) THEN printf('%!5.1f KB', sum(size) / 1024.0)
                WHEN sum(size) >= (1024 * 1024)  AND sum(size) < (1024 * 1024 * 1024) THEN printf('%!5.1f MB', sum(size) / 1024.0 / 1024)
                WHEN sum(size) >= (1024 * 1024 * 1024) THEN printf('%!5.1f GB', sum(size) / 1024.0 / 1024 / 1024)
            END AS pretty_total_size,
            sum(size) AS total_size, GROUP_CONCAT(asset_bundle, ',' || CHAR(13)) AS in_bundles
            FROM shader_view
            GROUP BY name
            ORDER BY total_size DESC, instances DESC
            """,
            """
            SELECT m.id material_id, m.name material_name, a.name material_path, m.asset_bundle material_asset_bundle, s.id shader_id, s.name shader_name, s.asset_bundle shader_asset_bundle
            FROM object_view m
            INNER JOIN refs r ON m.id = r.object AND r.property_path = 'm_Shader'
            INNER JOIN object_view s ON r.referenced_object = s.id
            LEFT JOIN assets a ON m.id = a.object
            """,
            """
            SELECT m.id material_id, m.name material_name, a.name material_path, m.asset_bundle material_asset_bundle, t.id texture_id, t.name texture_name, t.asset_bundle texture_asset_bundle
            FROM object_view m
            INNER JOIN refs r ON r.object = m.id AND property_type = "Texture"
            INNER JOIN object_view t ON r.referenced_object = t.id
            LEFT JOIN assets a ON m.id = a.object
            WHERE m.type = "Material"
            """,
            """
            SELECT COUNT(name) AS instances, name, type,
            CASE
            	WHEN sum(size) < 1024 THEN printf('%!5.1f B', sum(size) * 1.0)
            	WHEN sum(size) >=  1024 AND sum(size) < (1024 * 1024) THEN printf('%!5.1f KB', sum(size) / 1024.0)
            	WHEN sum(size) >= (1024 * 1024)  AND sum(size) < (1024 * 1024 * 1024) THEN printf('%!5.1f MB', sum(size) / 1024.0 / 1024)
            	WHEN sum(size) >= (1024 * 1024 * 1024) THEN printf('%!5.1f GB', sum(size) / 1024.0 / 1024 / 1024)
            END AS pretty_total_size,
            sum(size) AS total_size,
            size,
            pretty_size,
            REPLACE(GROUP_CONCAT(DISTINCT IIF(asset_bundle IS NULL, serialized_file, asset_bundle)), ',', ',' || CHAR(13)) AS in_files
            FROM object_view
            GROUP BY name, type, size, crc32
            HAVING instances > 1
            ORDER BY size DESC, instances DESC
            """
        ];
    }
}