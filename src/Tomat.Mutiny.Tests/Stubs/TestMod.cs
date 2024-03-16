using Semver;
using Tomat.Mutiny.Loader.API;
using Tomat.Mutiny.Loader.API.Schema;

namespace Tomat.Mutiny.Tests.Stubs;

internal sealed class TestMod(string id, SemVersion version) : IMod {
    public string Id { get; } = id;

    public SemVersion Version { get; } = version;

    public AbstractSchema Schema { get; } = new TestSchema {
        SchemaVersion = 1,
        Id = id,
        Version = version,
        Metadata = new SchemaMetadata(null, new Dictionary<string, string>(), [], []),
        Dependencies = new SchemaDependencies([], [], [], [], [], []),
        Etc = new SchemaEtc(new Dictionary<string, object?>()),
    };

    public Stream OpenFile(string path) {
        throw new NotImplementedException();
    }
}
