using Com.Afb.GridGame.Data.Model;
using UniRx;

namespace Com.Afb.GridGame.Business.UseCase {
    public interface IGridUseCase {
        // Properties
        IReadOnlyReactiveProperty<GridModel> GridModel { get; }
        // Methods
        void MarkCell((int x, int y) point);
        void SetGridSize(int gridSize);
    }
}

