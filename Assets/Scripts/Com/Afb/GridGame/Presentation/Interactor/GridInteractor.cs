using System;
using Com.Afb.GridGame.Business.UseCase;
using Com.Afb.GridGame.Data.Model;
using Com.Afb.GridGame.Presentation.Presenter;
using UniRx;
using UnityEngine;

namespace Com.Afb.GridGame.Presentation.Interactor {
    public class GridInteractor : IGridInteractor, IDisposable {
        // Readonly Properties
        private readonly CompositeDisposable disposables = new CompositeDisposable();
        private readonly IGridUseCase gridUseCase;
        private readonly IGridPresenter gridPresenter;

        // Constructor
        public GridInteractor(IGridUseCase gridUseCase, IGridPresenter gridPresenter) {
            this.gridUseCase = gridUseCase;
            this.gridPresenter = gridPresenter;

            gridUseCase.GridModel
                .Subscribe(OnGridModelUpdate)
                .AddTo(disposables);
        }

        // Public Methods
        public void Dispose() {
            disposables.Dispose();
        }

        public void OnClickCell(Vector2Int cellPosition) {
            gridUseCase.MarkCell((cellPosition.x, cellPosition.y));
        }

        public void SetGridSize(int gridSize) {
            gridUseCase.SetGridSize(gridSize);
        }

        // Private Methods
        private void OnGridModelUpdate(GridModel gridModel) {
            if (gridModel == null) {
                return;
            }

            gridPresenter.SetGridSize(gridModel.GridSize);
            gridPresenter.SetGridMatrix(gridModel.GridMatrix);
            gridPresenter.SetGridScore(gridModel.Count);
        }
    }
}

