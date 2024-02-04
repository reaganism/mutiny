using System.Collections.Generic;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     An author as represented in a schema.
/// </summary>
public sealed class SchemaAuthor {
    /// <summary>
    ///     The author's name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     The author's contacts.
    /// </summary>
    public Dictionary<string, string> Contact { get; }

    public SchemaAuthor(string name, Dictionary<string, string> contact) {
        Name = name;
        Contact = contact;
    }
}
