using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridScorePresenter {
        IReadOnlyReactiveProperty<int> GridScore { get; }
    }
}