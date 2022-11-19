using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridPresenter {
        IReadOnlyReactiveProperty<int> GridSize { get; }
    }

    public interface IUpdatableGridPresenter : IGridPresenter {
        void SetGridSize(int gridSize);
    }
}