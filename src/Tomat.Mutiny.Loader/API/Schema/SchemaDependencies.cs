using System.Collections.Generic;
using JetBrains.Annotations;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     Represents the dependencies of a schema.
/// </summary>
/// <param name="Provides">The dependencies that this mod provides.</param>
/// <param name="Depends">The dependencies that this mod depends on.</param>
/// <param name="Recommends">The dependencies that this mod recommends.</param>
/// <param name="Suggests">The dependencies that this mod suggests.</param>
/// <param name="Breaks">The dependencies that this mod breaks.</param>
/// <param name="Conflicts">The dependencies that this mod conflicts with.</param>
[PublicAPI]
public sealed record SchemaDependencies (List<SchemaDependency> Provides, List<SchemaDependency> Depends, List<SchemaDependency> Recommends, List<SchemaDependency> Suggests, List<SchemaDependency> Breaks, List<SchemaDependency> Conflicts);
