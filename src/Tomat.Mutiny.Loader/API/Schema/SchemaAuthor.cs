using System.Collections.Generic;
using JetBrains.Annotations;

namespace Tomat.Mutiny.Loader.API.Schema;

/// <summary>
///     An author as represented in a schema.
/// </summary>
/// <param name="Name">The author's name.</param>
/// <param name="Contact">The author's contacts.</param>
[PublicAPI]
public sealed record SchemaAuthor(string Name, Dictionary<string, string> Contact);
