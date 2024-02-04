namespace Tomat.Mutiny.Loader.API.Schema.V1;

internal interface ISchemaEtc {
    T? Get<T>(string key) where T : class;

    bool TryGet<T>(string key, out T? value) where T : class;

    void Set<T>(string key, T? value) where T : class;

    bool Remove(string key);
}
