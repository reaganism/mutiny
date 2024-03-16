using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Semver;

namespace Tomat.Mutiny.Loader.API;

/// <summary>
///     Simple representation of log levels for a loader, so implemented loggers
///     can convert to their own concept of log levels
/// </summary>
[PublicAPI]
public enum LoaderLogLevel {
    /// <summary>
    ///     Debug information.
    /// </summary>
    Debug,

    /// <summary>
    ///     General information used for purposes other than just debugging.
    /// </summary>
    Info,

    /// <summary>
    ///     Warnings.
    /// </summary>
    Warning,

    /// <summary>
    ///     Fatal and non-fatal errors.
    /// </summary>
    Error,
}

/// <summary>
///     Handler for loader log events, providing a <paramref name="level"/> and
///     <paramref name="message"/>.
/// </summary>
[PublicAPI]
public delegate void LoaderLogHandler(LoaderLogLevel level, string message);

/// <summary>
///     The rawest representation of a mod loader.
/// </summary>
[PublicAPI]
public interface ILoader {
    /// <summary>
    ///     Event that is called when the loader logs something.
    /// </summary>
    event LoaderLogHandler? Log;

    #region Probing / Initial Load Steps
    /// <summary>
    ///     Adds a probing path to the loader.
    /// </summary>
    /// <param name="directory">The directory to search for mods in.</param>
    /// <remarks>
    ///     Mods are only searched for within the top-level of the directory.
    ///     This is because mods may be things just as directories, so we should
    ///     not haphazardly probe through child directories; that should be
    ///     handled by implementers.
    /// </remarks>
    void AddProbingDirectory(string directory);
    #endregion

    #region Loader Features
    /// <summary>
    ///     Gets the status of a feature.
    /// </summary>
    /// <param name="feature">The feature ID.</param>
    /// <returns>The status of the feature.</returns>
    LoaderFeatureStatus GetFeatureStatus(string feature);

    /// <summary>
    ///     Sets the status of a feature.
    /// </summary>
    /// <param name="feature">The feature ID.</param>
    /// <param name="status">The status of the feature.</param>
    void SetFeatureStatus(string feature, LoaderFeatureStatus status);
    #endregion

    #region Mod Registration and Retrieval
    /// <summary>
    ///     Registers a mod with the loader.
    /// </summary>
    /// <returns>
    ///     <see langword="true"/> if the mod was registered; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    bool RegisterMod(IMod mod);

    /// <summary>
    ///     Tries to get a mod by its ID.
    /// </summary>
    /// <param name="id">The mod's ID.</param>
    /// <param name="mod">The mod.</param>
    /// <returns>
    ///     <see langword="true"/> if the mod was found; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    bool TryGetMod(string id, [NotNullWhen(returnValue: true)] out IMod? mod);

    /// <summary>
    ///     Gets all the mods that are currently loaded.
    /// </summary>
    /// <returns>
    ///     A collection of mods.
    /// </returns>
    IEnumerable<IMod> GetMods();

    bool SatisfiesDependency(string id, SemVersionRange range);
    #endregion
}
