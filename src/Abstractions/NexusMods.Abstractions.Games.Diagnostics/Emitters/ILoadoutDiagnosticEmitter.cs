using JetBrains.Annotations;
using NexusMods.Abstractions.Loadouts;

namespace NexusMods.Abstractions.Diagnostics.Emitters;

/// <summary>
/// Interface for diagnostic emitters that run on the entire <see cref="Loadout"/>.
/// </summary>
/// <remarks>
/// This interface should be implemented if the emitter has to look at the relationship
/// between mods to create diagnostics.
/// </remarks>
/// <seealso cref="IModDiagnosticEmitter"/>
[PublicAPI]
public interface ILoadoutDiagnosticEmitter
{
    /// <summary>
    /// Diagnoses a loadout and creates instances of <see cref="Diagnostic"/>.
    /// </summary>
    /// <param name="loadout">The current loadout.</param>
    IAsyncEnumerable<Diagnostic> Diagnose(Loadout loadout);
}
