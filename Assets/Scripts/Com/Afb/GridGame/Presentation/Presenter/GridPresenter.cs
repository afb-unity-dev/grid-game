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

        public void SetGridSize(int gridSize) {
            if (gridSize != GridSize.Value) {
                CreateMatrix(gridSize);
                this.gridSize.SetValueAndForceNotify(gridSize);
            }
        }

        public void SetGridMatrix(List<List<bool>> gridMatrixData) {
            int gridSize = GridSize.Value;

            for (int x = 0; x < gridSize; x++) {
                for (int y = 0; y < gridSize; y++) {
                    var cell = new ReactiveProperty<bool>(false);
                    gridMatrix[x][y].Value = gridMatrixData[x][y];
                }
            }
        }
    }
}
