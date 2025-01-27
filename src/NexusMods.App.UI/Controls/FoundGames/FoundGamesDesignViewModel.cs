using System.Collections.ObjectModel;
using NexusMods.Abstractions.Games;
using NexusMods.App.UI.Controls.GameWidget;

namespace NexusMods.App.UI.Controls.FoundGames;

public class FoundGamesDesignViewModel : AViewModel<IFoundGamesViewModel>, IFoundGamesViewModel
{

    public FoundGamesDesignViewModel()
    {
        var games = Enumerable.Range(0, 10)
            .Select(_ => new GameWidgetDesignViewModel());

        Games = new ReadOnlyObservableCollection<IGameWidgetViewModel>(new ObservableCollection<IGameWidgetViewModel>(games));
    }

    public ReadOnlyObservableCollection<IGameWidgetViewModel> Games { get; }
    public void InitializeFromFound(IEnumerable<IGame> games)
    {
        throw new NotImplementedException();
    }

    public void InitializeManual(IEnumerable<IGame> games)
    {
        throw new NotImplementedException();
    }
}
