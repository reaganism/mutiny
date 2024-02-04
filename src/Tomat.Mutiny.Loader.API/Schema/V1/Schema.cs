using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semver;

namespace Tomat.Mutiny.Loader.API.Schema.V1;

/// <summary>
///     Version 1 definition of the mod schema.
/// </summary>
internal static class Schema {
    private sealed class JsonSchema {
        [JsonProperty("schemaVersion")]
        public int SchemaVersion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;

        [JsonProperty("metadata")]
        public JsonSchemaMetadata? Metadata { get; set; }

        [JsonProperty("dependencies")]
        public JsonSchemaDependencies? Dependencies { get; set; }

        [JsonProperty("etc")]
        public Dictionary<string, object?>? Etc { get; set; }
    }

    private sealed class JsonSchemaMetadata {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("contact")]
        public Dictionary<string, string>? Contact { get; }

        [JsonProperty("authors")]
        public List<JsonSchemaAuthor>? Authors { get; }

        [JsonProperty("contributors")]
        public List<JsonSchemaAuthor>? Contributors { get; }
    }

    private sealed class JsonSchemaDependencies {
        [JsonProperty("provides")]
        public List<JsonSchemaDependency>? Provides { get; set; }

        [JsonProperty("depends")]
        public List<JsonSchemaDependency>? Depends { get; set; }

        [JsonProperty("recommends")]
        public List<JsonSchemaDependency>? Recommends { get; set; }

        [JsonProperty("suggests")]
        public List<JsonSchemaDependency>? Suggests { get; set; }

        [JsonProperty("breaks")]
        public List<JsonSchemaDependency>? Breaks { get; set; }

        [JsonProperty("conflicts")]
        public List<JsonSchemaDependency>? Conflicts { get; set; }
    }

    private sealed class JsonSchemaAuthor {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("contact")]
        public Dictionary<string, string>? Contact { get; }
    }

    private sealed class JsonSchemaDependency {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;
    }

    public static bool TryParse<T>(JObject jObject, [NotNullWhen(returnValue: true)] out T? schema) where T : AbstractSchema, new() {
        const int schema_version = 1;

        schema = null;

        var jsonSchema = jObject.ToObject<JsonSchema>();
        if (jsonSchema is null || jsonSchema.SchemaVersion != schema_version)
            return false;

        if (!SemVersion.TryParse(jsonSchema.Version, out var semverVersion))
            return false;

        var metadata = new SchemaMetadata(null, new Dictionary<string, string>(), new List<SchemaAuthor>(), new List<SchemaAuthor>());
        if (jsonSchema.Metadata is not null) {
            metadata = new SchemaMetadata(
                jsonSchema.Metadata.Name,
                jsonSchema.Metadata.Contact ?? new Dictionary<string, string>(),
                jsonSchema.Metadata.Authors?.Select(author => new SchemaAuthor(author.Name, author.Contact ?? new Dictionary<string, string>())).ToList() ?? new List<SchemaAuthor>(),
                jsonSchema.Metadata.Contributors?.Select(contributor => new SchemaAuthor(contributor.Name, contributor.Contact ?? new Dictionary<string, string>())).ToList() ?? new List<SchemaAuthor>()
            );
        }

        var dependencies = new SchemaDependencies(new List<SchemaDependency>(), new List<SchemaDependency>(), new List<SchemaDependency>(), new List<SchemaDependency>(), new List<SchemaDependency>(), new List<SchemaDependency>());
        if (jsonSchema.Dependencies is not null) {
            dependencies = new SchemaDependencies(
                jsonSchema.Dependencies.Provides?.Select(provides => new SchemaDependency(provides.Id, SemVersionRange.Parse(provides.Version))).ToList() ?? new List<SchemaDependency>(),
                jsonSchema.Dependencies.Depends?.Select(depends => new SchemaDependency(depends.Id, SemVersionRange.Parse(depends.Version))).ToList() ?? new List<SchemaDependency>(),
                jsonSchema.Dependencies.Recommends?.Select(recommends => new SchemaDependency(recommends.Id, SemVersionRange.Parse(recommends.Version))).ToList() ?? new List<SchemaDependency>(),
                jsonSchema.Dependencies.Suggests?.Select(suggests => new SchemaDependency(suggests.Id, SemVersionRange.Parse(suggests.Version))).ToList() ?? new List<SchemaDependency>(),
                jsonSchema.Dependencies.Breaks?.Select(breaks => new SchemaDependency(breaks.Id, SemVersionRange.Parse(breaks.Version))).ToList() ?? new List<SchemaDependency>(),
                jsonSchema.Dependencies.Conflicts?.Select(conflicts => new SchemaDependency(conflicts.Id, SemVersionRange.Parse(conflicts.Version))).ToList() ?? new List<SchemaDependency>()
            );
        }

        schema = new T {
            SchemaVersion = schema_version,
            Id = jsonSchema.Id,
            Version = semverVersion,
            Metadata = metadata,
            Dependencies = dependencies,
            Etc = new SchemaEtc(jsonSchema.Etc ?? new Dictionary<string, object?>()),
        };

        return true;
    }
}
