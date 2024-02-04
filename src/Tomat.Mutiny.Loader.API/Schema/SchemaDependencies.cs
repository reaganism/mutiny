using System.Collections.Generic;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     Represents the dependencies of a schema.
/// </summary>
public sealed class SchemaDependencies {
    /// <summary>
    ///     The dependencies that this mod provides.
    /// </summary>
    public List<SchemaDependency> Provides { get; }

    /// <summary>
    ///     The dependencies that this mod depends on.
    /// </summary>
    public List<SchemaDependency> Depends { get; }

    /// <summary>
    ///     The dependencies that this mod recommends.
    /// </summary>
    public List<SchemaDependency> Recommends { get; }

    /// <summary>
    ///     The dependencies that this mod suggests.
    /// </summary>
    public List<SchemaDependency> Suggests { get; }

    /// <summary>
    ///     The dependencies that this mod breaks.
    /// </summary>
    public List<SchemaDependency> Breaks { get; }

    /// <summary>
    ///     The dependencies that this mod conflicts with.
    /// </summary>
    public List<SchemaDependency> Conflicts { get; }

    public SchemaDependencies(List<SchemaDependency> provides, List<SchemaDependency> depends, List<SchemaDependency> recommends, List<SchemaDependency> suggests, List<SchemaDependency> breaks, List<SchemaDependency> conflicts) {
        Provides = provides;
        Depends = depends;
        Recommends = recommends;
        Suggests = suggests;
        Breaks = breaks;
        Conflicts = conflicts;
    }
}
