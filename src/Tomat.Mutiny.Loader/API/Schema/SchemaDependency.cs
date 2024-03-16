using JetBrains.Annotations;
using Semver;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     Represents a dependency of a schema.
/// </summary>
/// <param name="Id">The ID of the dependency.</param>
/// <param name="VersionRange">The version range of the dependency.</param>
[PublicAPI]
public sealed record SchemaDependency (string Id, SemVersionRange VersionRange);
