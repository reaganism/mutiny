using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Semver;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     The abstracted mod schema format, providing essential data.
/// </summary>
/// <remarks>
///     Custom mod schemas should inherit from this class and provide properties
///     that interface with the <see cref="Etc"/> property; custom schemas
///     should not directly define new JSON properties.
///     <br />
///     <see cref="AbstractSchema"/> defines base properties expected by all mod
///     schemas.
/// </remarks>
[PublicAPI]
public abstract class AbstractSchema {
    /// <summary>
    ///     The version of the schema.
    /// </summary>
    public required int SchemaVersion { get; init; }

    /// <summary>
    ///     The ID of the mod.
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    ///     The SemVer-compliant version of the mod.
    /// </summary>
    public required SemVersion Version { get; init; }

    /// <summary>
    ///     The unessential metadata of the mod.
    /// </summary>
    public required SchemaMetadata Metadata { get; init; }

    /// <summary>
    ///     The dependencies of the mod.
    /// </summary>
    public required SchemaDependencies Dependencies { get; init; }

    /// <summary>
    ///     Additional objects.
    /// </summary>
    public required SchemaEtc Etc { get; init; }

    /// <summary>
    ///     Attempts to parse a JSON string into a schema.
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="schema">The resulting schema.</param>
    /// <typeparam name="T">The schema type.</typeparam>
    /// <returns>
    ///     <see langword="true"/> if the JSON string was successfully parsed;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool TryParse<T>(string json, [NotNullWhen(returnValue: true)] out T? schema) where T : AbstractSchema, new() {
        schema = null;

        try {
            var jObject = JObject.Parse(json);
            if (!jObject.TryGetValue("schemaVersion", out var schemaVersionToken))
                return false;

            if (schemaVersionToken.Type != JTokenType.Integer)
                return false;

            return schemaVersionToken.Value<int>() switch {
                1 => V1.Schema.TryParse(jObject, out schema),
                _ => false,
            };
        }
        catch {
            return false;
        }
    }
}
