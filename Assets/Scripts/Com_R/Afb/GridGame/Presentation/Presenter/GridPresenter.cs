using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public class GridPresenter : IUpdatableGridPresenter {
        // Readonly Properties
        private readonly ReactiveProperty<int> gridSize = new ReactiveProperty<int>(0);

        // Public Properties
        public IReadOnlyReactiveProperty<int> GridSize => gridSize;

        public void SetGridSize(int gridSize) {
            this.gridSize.SetValueAndForceNotify(gridSize);
        }
    }
}
