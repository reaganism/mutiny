# mutiny

> Open rebellion; my response to mod loaders.

---

Mutiny is a personal project of mine: a way to combat my frustrations with the current status of mod loaders, especially in the realm of .NET games. I'm tired of dealing with different APIs.

Mutiny intends to define and implement a standardized API for loading mods and dependencies, including a plugin system to augment the base loader and allow arbitrary loading for further mods.

The Mutiny API targets .NET Standards and abstracts away the loading process to allow for both `AppDomain` and `AssemblyLoadContext` loading.
