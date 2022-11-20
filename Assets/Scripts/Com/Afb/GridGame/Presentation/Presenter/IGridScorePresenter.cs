using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridScorePresenter {
        // Properties
        IReadOnlyReactiveProperty<int> GridScore { get; }
    }
}