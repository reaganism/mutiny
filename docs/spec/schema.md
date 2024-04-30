# Mod Schema

The "mod schema" is an abstracted representation of both vital and unimportant metadata provided by a mod.
The schema may provide crucial information such as a unique identifier and dependencies, as well as vanity and legal information such as authorship and licenses.

In the API, a schema is represented by an abstract `AbstractSchema` type that implementation-specific schemas may inherit from[^1].

[^1]: SUbject to change.
