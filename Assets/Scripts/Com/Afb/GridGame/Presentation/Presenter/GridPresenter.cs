using System.Collections.Generic;
using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public class GridPresenter : IGridPresenter {
        // Readonly Properties
        private readonly ReactiveProperty<int> gridSize = new ReactiveProperty<int>(0);
        private readonly ReactiveProperty<int> gridScore = new ReactiveProperty<int>(0);
        private readonly ReactiveProperty<List<List<bool>>> gridMatrix = new ReactiveProperty<List<List<bool>>>(null);

        // Public Properties
        public IReadOnlyReactiveProperty<int> GridSize => gridSize;
        public IReadOnlyReactiveProperty<List<List<bool>>> GridMatrix => gridMatrix;
        public IReadOnlyReactiveProperty<int> GridScore => gridScore;

        // Public Methods
        public void SetGridSize(int gridSize) {
            if (gridSize != GridSize.Value) {
                gridMatrix.Value = null;
                this.gridSize.SetValueAndForceNotify(gridSize);
                CreateMatrix(gridSize);
            }
        }

        public void SetGridMatrix(List<List<bool>> gridMatrixData) {
            gridMatrix.SetValueAndForceNotify(gridMatrixData);
        }

        public void SetGridScore(int gridScore) {
            this.gridScore.Value = gridScore;
        }

        // Private Methods
        private void CreateMatrix(int gridSize) {
            var list = new List<List<bool>>();

            for (int x = 0; x < gridSize; x++) {
                var horizontal = new List<bool>();
                list.Add(horizontal);

                for (int y = 0; y < gridSize; y++) {
                    horizontal.Add(false);
                }
            }

            SetGridMatrix(list);
        }
    }
}
