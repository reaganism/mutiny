using JetBrains.Annotations;

namespace Tomat.Mutiny.Loader;

/// <summary>
///     The status of a loader feature.
/// </summary>
[PublicAPI]
public enum LoaderFeatureStatus {
    /// <summary>
    ///     This feature is fully supported.
    /// </summary>
    Supported,
    
    /// <summary>
    ///     This feature is unsupported.
    /// </summary>
    Unsupported,
}

/// <summary>
///     Defines well-known loader feature ID constants.
/// </summary>
[PublicAPI]
public static class WellKnownLoaderFeatures {
    /// <summary>
    ///     Whether this loader uses AppDomain assembly loading.
    /// </summary>
    public const string USES_APPDOMAIN = "dev.tomat.mutiny.loader.uses_appdomain";
    
    /// <summary>
    ///     Whether this loader uses AssemblyLoadContext assembly loading.
    /// </summary>
    public const string USES_ASSEMBLYLOADCONTEXT = "dev.tomat.mutiny.loader.uses_assemblyloadcontext";
    
    /// <summary>
    ///     Whether this loader supports isolating mod dependency assemblies
    ///     from each other.
    /// </summary>
    public const string SUPPORTS_DEPENDENCY_ISOLATION = "dev.tomat.mutiny.loader.supports_dependency_isolation";
}
