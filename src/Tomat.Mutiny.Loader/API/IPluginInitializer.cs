using JetBrains.Annotations;

namespace Tomat.Mutiny.Loader.API;

/// <summary>
///     A plugin initializer, which, when implemented, will be called when a
///     loader plugin is loaded (denoted by the inclusion of a
///     <c>mutiny.plugin.json</c> file).
/// </summary>
[PublicAPI]
[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public interface IPluginInitializer {
    /// <summary>
    ///     Called when the plugin is loaded.
    /// </summary>
    /// <param name="loader">The <see cref="ILoader"/> </param>
    void Initialize(ILoader loader);
}
