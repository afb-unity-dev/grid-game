using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridSizePresenter {
        // Properties
        IReadOnlyReactiveProperty<int> GridSize { get; }
    }
}