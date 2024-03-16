using Tomat.Mutiny.Loader;

namespace Tomat.Mutiny.Tests.Stubs;

internal sealed class TestLoader : AbstractLoader {
    public TestLoader() {
        SetFeatureStatus(WellKnownLoaderFeatures.USES_APPDOMAIN, LoaderFeatureStatus.Unsupported);
        SetFeatureStatus(WellKnownLoaderFeatures.USES_ASSEMBLYLOADCONTEXT, LoaderFeatureStatus.Unsupported);
        SetFeatureStatus(WellKnownLoaderFeatures.SUPPORTS_DEPENDENCY_ISOLATION, LoaderFeatureStatus.Unsupported);
    }
}
