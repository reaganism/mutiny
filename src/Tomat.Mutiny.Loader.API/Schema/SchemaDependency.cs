using Semver;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     Represents a dependency of a schema.
/// </summary>
public sealed class SchemaDependency {
    /// <summary>
    ///     The ID of the dependency.
    /// </summary>
    public string Id { get; }

    /// <summary>
    ///     The version range of the dependency.
    /// </summary>
    public SemVersionRange VersionRange { get; }

    public SchemaDependency(string id, SemVersionRange versionRange) {
        Id = id;
        VersionRange = versionRange;
    }
}
