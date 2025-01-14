using NexusMods.Abstractions.DataModel.Entities.Sorting;
using NexusMods.Abstractions.Loadouts.Mods;

namespace NexusMods.Abstractions.Installers;

/// <summary>
/// Return value of <see cref="IModInstaller"/>. Maps to <see cref="Mod"/> in <see cref="LoadoutManager"/>.
/// </summary>
public record ModInstallerResult
{
    /// <summary>
    /// Unique identifier of the mod.
    /// </summary>
    public required ModId Id { get; init; }

    /// <summary>
    /// All files belonging to the mod.
    /// </summary>
    public required IEnumerable<AModFile> Files { get; init; }

    /// <summary>
    /// Optional name of the mod.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Optional version of the mod.
    /// </summary>
    public string? Version { get; init; }

    /// <summary>
    /// Optional sort rules for the mod.
    /// </summary>
    public IEnumerable<ISortRule<Mod, ModId>>? SortRules { get; init; }
}
