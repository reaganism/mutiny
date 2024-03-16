using JetBrains.Annotations;
using Tomat.Mutiny.Loader.API;

namespace Tomat.Mutiny;

/// <summary>
///     Base .NET Core implementation of <see cref="ILoader"/> and
///     <see cref="AbstractLoader"/>.
/// </summary>
[PublicAPI]
public abstract class NetCoreLoader : AbstractLoader;
