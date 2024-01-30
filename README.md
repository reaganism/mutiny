# mutiny

> Open rebellion; my response to mod loaders.

---

Mutiny is a personal project of mine aiming to define a unified, consistent modding API that is hosted through the .NET runtime. Ideally defined almost entirely through .NET Standard, it intends to remain compatible with both .NET Framework and .NET Core+ for various modding means.

Mutiny defines a standardized API for mod loading, and a plugin system to augment any loaders implementing the Mutiny API. It is abstracted to allow for loading through both `AppDomain`s and `AssemblyLoadContext`.
