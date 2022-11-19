using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridSizePresenter {
        IReadOnlyReactiveProperty<int> GridSize { get; }
    }
}