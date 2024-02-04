using System.Collections.Generic;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     Represents the unessential metadata of a schema.
/// </summary>
public sealed class SchemaMetadata {
    /// <summary>
    ///     The display name (typically in English) of the mod.
    /// </summary>
    public string? Name { get; }

    /// <summary>
    ///     The contact information for the mod.
    /// </summary>
    public Dictionary<string, string> Contact { get; }

    /// <summary>
    ///     The authors of the mod.
    /// </summary>
    public List<SchemaAuthor> Authors { get; }

    /// <summary>
    ///     The contributors to the mod.
    /// </summary>
    public List<SchemaAuthor> Contributors { get; }

    public SchemaMetadata(string? name, Dictionary<string, string> contact, List<SchemaAuthor> authors, List<SchemaAuthor> contributors) {
        Name = name;
        Contact = contact;
        Authors = authors;
        Contributors = contributors;
    }
}
