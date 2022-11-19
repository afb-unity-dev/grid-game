using Com.Afb.GridGame.Presentation.Presenter;

namespace Com.Afb.GridGame.Presentation.Interactor {
    public interface IGridInteractor {
        IGridSizePresenter GridSizePresenter { get; }
    }
}