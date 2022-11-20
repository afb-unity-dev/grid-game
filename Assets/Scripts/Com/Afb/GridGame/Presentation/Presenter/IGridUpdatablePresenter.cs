using System.Collections.Generic;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridUpdatablePresenter {
        void SetGridSize(int gridSize);
        void SetGridMatrix(List<List<bool>> gridMatrix);
        void SetGridScore(int gridScore);
    }
}