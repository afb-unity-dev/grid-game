using System.Collections.Generic;
using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public class GridPresenter : IGridPresenter {
        // Readonly Properties
        private readonly ReactiveProperty<int> gridSize = new ReactiveProperty<int>(0);

        // Private Properties
        private List<List<ReactiveProperty<bool>>> gridMatrix = null;

        // Public Properties
        public IReadOnlyReactiveProperty<int> GridSize => gridSize;
        public IReadOnlyList<IReadOnlyList<IReadOnlyReactiveProperty<bool>>> GridMatrix => gridMatrix;

        public void SetGridSize(int gridSize) {
            CreateMatrix(gridSize);

            this.gridSize.SetValueAndForceNotify(gridSize);
        }

        private void CreateMatrix(int gridSize) {
            gridMatrix = new List<List<ReactiveProperty<bool>>>();

            for (int x = 0; x < gridSize; x++) {
                var horizontal = new List<ReactiveProperty<bool>>();
                gridMatrix.Add(horizontal);

                for (int y = 0; y < gridSize; y++) {
                    var cell = new ReactiveProperty<bool>(false);
                    horizontal.Add(cell);
                }
            }
        }
    }
}
