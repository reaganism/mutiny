using System.Collections.Generic;

namespace Tomat.Mutiny.Loader.API.Schema.V1;

internal interface ISchemaMetadata {
    public string? Name { get; }

    public Dictionary<string, string> Contact { get; }

    public List<SchemaAuthor> Authors { get; }

    public List<SchemaAuthor> Contributors { get; }
}
