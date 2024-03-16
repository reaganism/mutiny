using System.IO;
using JetBrains.Annotations;
using Semver;
using Tomat.Mutiny.Loader.API.Schema;

namespace Tomat.Mutiny.Loader.API;

/// <summary>
///     Describes the rawest form of a mod.
/// </summary>
[PublicAPI]
public interface IMod {
    /// <summary>
    ///     The ID of the mod.
    /// </summary>
    string Id { get; }

    /// <summary>
    ///     The version of the mod.
    /// </summary>
    SemVersion Version { get; }

    /// <summary>
    ///     The schema of the mod.
    /// </summary>
    AbstractSchema Schema { get; }

    /// <summary>
    ///     Opens a stream to a file within a mod. A mod may be represented as
    ///     an assembly, a directory, or some other concept. This method acts
    ///     as an abstraction over obtaining resources belonging to a mod.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>
    ///     A <see cref="Stream"/> representing the file, or
    ///     <see langword="null"/> if the file could not be found.
    /// </returns>
    Stream? OpenFile(string path);
}
