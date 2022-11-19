using Com.Afb.GridGame.Presentation.Interactor;
using UniRx;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Presentation.View {
    public class GridView : MonoBehaviour {
        // Dependencies
        [Inject]
        private IGridInteractor gridInteractor;

        private void Start() {
            Initiaize();
        }

        private void Initiaize() {
            gridInteractor.GridPresenter.GridSize
                .Subscribe(OnGridSizeUpdate);
        }

        private void OnGridSizeUpdate(int gridSize) {
            Debug.Log("GridView - GridSize: " + gridSize);
            ClearGrid();
            CreateGrid(gridSize);
        }

        private void ClearGrid() {

        }

        private void CreateGrid(int gridSize) {
            if (gridSize == 0) {
                return;
            }
        }
    }
}
