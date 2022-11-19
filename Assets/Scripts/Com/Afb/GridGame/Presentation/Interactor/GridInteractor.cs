using System;
using Com.Afb.GridGame.Business.UseCase;
using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Presentation.Presenter;
using UniRx;
using UnityEngine;

namespace Com.Afb.GridGame.Presentation.Interactor {
    public class GridInteractor : IGridClickInteractor, IDisposable {
        // Readonly Properties
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        // Readonly Properties
        private readonly IGridUseCase gridUseCase;
        private readonly IGridPresenter gridPresenter;

        public GridInteractor(IGridUseCase gridUseCase, IGridPresenter gridPresenter) {
            this.gridUseCase = gridUseCase;
            this.gridPresenter = gridPresenter;

            gridUseCase.GridModel
                .Subscribe(OnGridModelUpdate)
                .AddTo(disposables);
        }

        public void Dispose() {
            disposables.Dispose();
        }

        private void OnGridModelUpdate(GridModel gridModel) {
            if (gridModel == null) {
                return;
            }

            gridPresenter.SetGridSize(gridModel.GridSize);
            gridPresenter.SetGridMatrix(gridModel.GridMatrix);
        }

        public void OnClickCell(Vector2Int cellPosition) {
            gridUseCase.MarkCell(cellPosition.x, cellPosition.y);
        }
    }
}

