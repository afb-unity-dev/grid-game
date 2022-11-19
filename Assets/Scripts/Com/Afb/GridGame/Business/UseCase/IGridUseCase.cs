using Com.Afb.GridGame.Data.Dto;
using UniRx;

namespace Com.Afb.GridGame.Business.UseCase {
    public interface IGridUseCase {
        IReadOnlyReactiveProperty<GridModel> GridModel { get; }
        void MarkCell(int x, int y);
    }
}

