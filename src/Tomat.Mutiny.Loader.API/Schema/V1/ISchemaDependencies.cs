using System.Collections.Generic;

namespace Tomat.Mutiny.Loader.API.Schema.V1;

internal interface ISchemaDependencies {
    List<SchemaDependency> Provides { get; }

    List<SchemaDependency> Depends { get; }

    List<SchemaDependency> Recommends { get; }

    List<SchemaDependency> Suggests { get; }

    List<SchemaDependency> Breaks { get; }

    List<SchemaDependency> Conflicts { get; }
}
