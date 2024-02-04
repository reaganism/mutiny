using System.Collections.Generic;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     Exposes additional information included within a schema.
/// </summary>
public sealed class SchemaEtc {
    private readonly Dictionary<string, object?> data;

    /// <summary>
    ///     Creates a new instance of <see cref="SchemaEtc"/>.
    /// </summary>
    /// <param name="data">The data to expose.</param>
    public SchemaEtc(Dictionary<string, object?> data) {
        this.data = data;
    }

    /// <summary>
    ///     Gets the value of a key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <typeparam name="T">
    ///     The type to handle as, use <see langword="object"/> if the type is
    ///     unknown or inaccessible.
    /// </typeparam>
    /// <returns>
    ///     The value of the key, which is possibly <see langword="null"/> iff:
    ///     1. the property of the schema is null or 2. the object could not be
    ///     casted. If a property is not present, an exception is thrown.
    /// </returns>
    /// <exception cref="KeyNotFoundException">The key is not found.</exception>
    public T? Get<T>(string key) where T : class {
        return data[key] as T;
    }

    /// <summary>
    ///     Tries to get the value of a key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">
    ///     The value of the key, if found. Possibly <see langword="null"/> iff:
    ///     1. the property of the schema is null or 2. the object could not be
    ///     casted.
    /// </param>
    /// <typeparam name="T">
    ///     The type to handle as, use <see langword="object"/> if the type is
    ///     unknown or inaccessible.
    /// </typeparam>
    /// <returns>
    ///     <see langword="true"/> if the key is found; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public bool TryGet<T>(string key, out T? value) where T : class {
        if (data.TryGetValue(key, out var obj)) {
            value = obj as T;
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    ///     Sets the value of a key.
    /// </summary>
    /// <param name="key">The key to set the value of.</param>
    /// <param name="value">The value to set.</param>
    /// <typeparam name="T">
    ///     The object type, unimportant but specified for consistency.
    /// </typeparam>
    public void Set<T>(string key, T? value) where T : class {
        data[key] = value;
    }

    /// <summary>
    ///     Removes a key from the dictionary.
    /// </summary>
    /// <param name="key">The key to remove.</param>
    /// <returns>Whether a key was removed.</returns>
    public bool Remove(string key) {
        return data.Remove(key);
    }
}
