using System.Collections.Generic;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     Represents the unessential metadata of a schema.
/// </summary>
/// <param name="Name">The display name (typically in English) of the mod.</param>
/// <param name="Contact">The contact information for the mod.</param>
/// <param name="Authors">The authors of the mod.</param>
/// <param name="Contributors">The contributors to the mod.</param>
public sealed record SchemaMetadata (string? Name, Dictionary<string, string> Contact, List<SchemaAuthor> Authors, List<SchemaAuthor> Contributors);
