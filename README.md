# mutiny

> i stuck a dotnet runtime in your game and called it a mod loader

---

Mutiny is a mod loader API and implementation designed to be general-purpose and easily implementable.

It aims to be flexible enough to be used in nearly any context, both within existing .NET contexts and environments in which one may choose to host their own .NET runtime.

Mutiny is, in part, a response to the fragmented nature of modding games—especially those builty with XNA or Unity and targeting .NET.

Mutiny intends to define and implement a standardized API for discovering and loading mods and their dependencies, including a built-in plugin system to augment the base loader implementation with further support, allowing for arbitrary loading of any content.

The Mutiny API targets .NET Standard to maximize compatibility.
