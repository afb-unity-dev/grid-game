using System;
using Com.Afb.GridGame.Business.UseCase;
using Com.Afb.GridGame.Presentation.Presenter;
using UniRx;
using Com.Afb.GridGame.Data.Dto;

namespace Com.Afb.GridGame.Presentation.Interactor {
    public class GridInteractor : IGridInteractor, IDisposable {
        // Readonly Properties
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        // Readonly Properties
        private readonly IGridUseCase gridUseCase;
        private readonly IUpdatableGridPresenter gridPresenter;

        // Public Properties
        public IGridPresenter GridPresenter => gridPresenter;

        public GridInteractor(IGridUseCase gridUseCase, IUpdatableGridPresenter gridPresenter) {
            this.gridUseCase = gridUseCase;
            this.gridPresenter = gridPresenter;

            gridUseCase.GridModel.Subscribe(OnGridModelUpdate).AddTo(disposables);
        }

        public void Dispose() {
            disposables.Dispose();
        }

        private void OnGridModelUpdate(GridModel gridModel) {
            if (gridModel == null) {
                return;
            }

            gridPresenter.SetGridSize(gridModel.GridSize);
        }
    }
}

