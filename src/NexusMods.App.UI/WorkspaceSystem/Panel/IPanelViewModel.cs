using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia;
using ReactiveUI;

namespace NexusMods.App.UI.WorkspaceSystem;

public interface IPanelViewModel : IViewModelInterface
{
    /// <summary>
    /// Gets the unique panel identifier.
    /// </summary>
    public PanelId Id { get; }

    /// <summary>
    /// Gets the read-only observable collection of all tabs of the panel.
    /// </summary>
    public ReadOnlyObservableCollection<IPanelTabViewModel> Tabs { get; }

    /// <summary>
    /// Gets or sets the current selected tab.
    /// </summary>
    public IPanelTabViewModel? SelectedTab { get; set; }

    /// <summary>
    /// Gets the contents of the selected tab.
    /// </summary>
    public IViewModel? SelectedTabContents { get; }

    /// <summary>
    /// Gets the command for closing this panel.
    /// </summary>
    public ReactiveCommand<Unit, Unit> CloseCommand { get; }

    /// <summary>
    /// Gets or sets the logical bounds the panel.
    /// </summary>
    /// <remarks>
    /// The logical bounds describe the ratio of space the panel takes up inside the workspace.
    /// The values range from 0.0 up to and including 1.0, where 0.0 means 0% of the space and 1.0
    /// means 100% of the space.
    /// </remarks>
    /// <seealso cref="ActualBounds"/>
    public Rect LogicalBounds { get; set; }

    /// <summary>
    /// Gets the actual bounds of the panel.
    /// </summary>
    /// <remarks>
    /// This is the actual size and position of the panel element inside the workspace canvas.
    /// </remarks>
    /// <seealso cref="LogicalBounds"/>
    public Rect ActualBounds { get; }

    /// <summary>
    /// Updates the <see cref="ActualBounds"/> using the new workspace size.
    /// </summary>
    public void Arrange(Size workspaceSize);

    /// <summary>
    /// Adds a new tab to the panel.
    /// </summary>
    public IPanelTabViewModel AddTab();
}
