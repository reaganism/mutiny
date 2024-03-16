using JetBrains.Annotations;
using Tomat.Mutiny.Loader.API;

namespace Tomat.Mutiny;

/// <summary>
///     Base .NET Framework implementation of <see cref="ILoader"/> and
///     <see cref="AbstractLoader"/>.
/// </summary>
[PublicAPI]
public abstract class NetFrameworkLoader : AbstractLoader;
