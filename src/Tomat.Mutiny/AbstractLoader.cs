using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Semver;
using Tomat.Mutiny.Loader;
using Tomat.Mutiny.Loader.API;

namespace Tomat.Mutiny;

/// <summary>
///     Abstractions over the <see cref="ILoader"/> interface that allow for
///     easier implementations of loaders. Handles basic functionality that
///     generally should not differ between implementations.
/// </summary>
[PublicAPI]
public abstract class AbstractLoader : ILoader {
    private readonly Dictionary<string, LoaderFeatureStatus> features = new();
    private readonly Dictionary<string, IMod> mods = new();
    private readonly Dictionary<string, SemVersionRange> providedMods = new();
    private readonly List<string> remainingProbingDirectories = [];

    public event LoaderLogHandler? Log;

    #region Probing / Initial Load Steps
    public virtual void AddProbingDirectory(string directory) {
        remainingProbingDirectories.Add(directory);
    }
    #endregion

    #region Loader Features
    public LoaderFeatureStatus GetFeatureStatus(string feature) {
        return features.TryGetValue(feature, out var status) ? status : LoaderFeatureStatus.Unsupported;
    }

    public void SetFeatureStatus(string feature, LoaderFeatureStatus status) {
        features[feature] = status;
    }
    #endregion

    #region Mod Registration and Retrieval
    public virtual bool RegisterMod(IMod mod) {
        if (mods.ContainsKey(mod.Id)) {
            Log?.Invoke(LoaderLogLevel.Warning, $"Attempted to register mod with ID '{mod.Id}' but this ID is already registered!");
            return false;
        }

        if (providedMods.ContainsKey(mod.Id)) {
            Log?.Invoke(LoaderLogLevel.Warning, $"Attempted to register mod with ID '{mod.Id}' but this ID is already provided by another mod!");
            return false;
        }

        // Check for duplicates before actually adding, so we don't accidentally
        // leave provided entries that shouldn't be there.
        foreach (var provided in mod.Schema.Dependencies.Provides) {
            if (!providedMods.ContainsKey(provided.Id))
                continue;

            Log?.Invoke(LoaderLogLevel.Warning, $"Attempted to register mod with ID '{mod.Id}' which provides '{provided.Id}' but this ID is already provided by another mod!");
            return false;
        }

        foreach (var provided in mod.Schema.Dependencies.Provides) {
            providedMods[provided.Id] = provided.VersionRange;
        }

        mods.Add(mod.Id, mod);
        providedMods[mod.Id] = SemVersionRange.Parse(mod.Version.ToString());
        return true;
    }

    public virtual bool TryGetMod(string id, [NotNullWhen(returnValue: true)] out IMod? mod) {
        return mods.TryGetValue(id, out mod);
    }

    public virtual IEnumerable<IMod> GetMods() {
        return mods.Values;
    }

    public virtual bool SatisfiesDependency(string id, SemVersionRange range) {
        // IMPLEMENTATION NOTES:
        // We face a rather peculiar problem here: comparing two SemVer ranges.
        // We take an input 'range' that is a dependency range, which we'll
        // assume is a known version ('1.0.0') or a reasonable range ('^1.0.0').
        // We want to make sure this input falls under the 'providedRange' range
        // acquired by a mod itself or whatever it claims to provide. These
        // ranges will tend to match in larger swathes ('^1.0.0', or maybe even
        // something greater like '>=1.0.0').
        // We can't compare the two ranges directly as the SemVer package
        // doesn't allow for this; instead, we'll have to compare to the
        // unbroken ranges within.
        return providedMods.TryGetValue(id, out var providedRange) && range.Any(innerRange => providedRange.Contains(innerRange));
    }
    #endregion
}
