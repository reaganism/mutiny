using Semver;
using Tomat.Mutiny.Loader.API.Schema;
using Tomat.Mutiny.Tests.Stubs;

namespace Tomat.Mutiny.Tests;

[TestFixture]
public static class ModVersionCollisionTests {
    [Test]
    public static void ModsWithTheSameIdAndVersion() {
        var loader = new TestLoader();

        if (!loader.RegisterMod(new TestMod("test", new SemVersion(1, 0, 0))))
            throw new Exception();

        if (loader.RegisterMod(new TestMod("test", new SemVersion(1, 0, 0))))
            throw new Exception();
    }

    [Test]
    public static void ModsWithTheSameIdAndDifferentVersions() {
        var loader = new TestLoader();

        if (!loader.RegisterMod(new TestMod("test", new SemVersion(1, 0, 0))))
            throw new Exception();

        if (loader.RegisterMod(new TestMod("test", new SemVersion(1, 0, 1))))
            throw new Exception();
    }

    [Test]
    public static void RegisterModAndThenModThatProvidesTheFirstOnesId() {
        var loader = new TestLoader();

        if (!loader.RegisterMod(new TestMod("test", new SemVersion(1, 0, 0))))
            throw new Exception();

        var test2 = new TestMod("test2", new SemVersion(1, 0, 0));
        test2.Schema.Dependencies.Provides.Add(new SchemaDependency("test", SemVersionRange.Parse("^1.0.0")));
        if (loader.RegisterMod(test2))
            throw new Exception();
    }

    [Test]
    public static void RegisterModThatProvidesIdOfAModThatIsLaterLoaded() {
        var loader = new TestLoader();

        var test = new TestMod("test", new SemVersion(1, 0, 0));
        test.Schema.Dependencies.Provides.Add(new SchemaDependency("test2", SemVersionRange.Parse("^1.0.0")));
        if (!loader.RegisterMod(test))
            throw new Exception();

        if (loader.RegisterMod(new TestMod("test2", new SemVersion(1, 0, 0))))
            throw new Exception();
    }
}
