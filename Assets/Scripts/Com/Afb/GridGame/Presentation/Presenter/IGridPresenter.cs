using System.Collections.Generic;
using UniRx;

namespace Com.Afb.GridGame.Presentation.Presenter {
    public interface IGridSizePresenter {
        IReadOnlyReactiveProperty<int> GridSize { get; }
    }

    public interface IGridMatrixPresenter {
        IReadOnlyList<IReadOnlyList<IReadOnlyReactiveProperty<bool>>> GridMatrix { get; }
    }

    public interface IGridUpdatablePresenter {
        void SetGridSize(int gridSize);
    }

    public interface IGridPresenter : IGridSizePresenter, IGridMatrixPresenter, IGridUpdatablePresenter {
    } 


}