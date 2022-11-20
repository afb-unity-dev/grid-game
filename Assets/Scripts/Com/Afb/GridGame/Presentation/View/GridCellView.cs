using System.Collections.Generic;
using Com.Afb.GridGame.Presentation.Interactor;
using Com.Afb.GridGame.Presentation.Presenter;
using UniRx;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Presentation.View {
    public class GridCellView : MonoBehaviour, IPoolable<Transform, Vector3, Vector2Int, Vector2>, IClickableView {
        // Serialize Fields
        [SerializeField]
        private GridCellMarkView gridCellMarkView;

        // Dependencies
        [Inject]
        private IGridMatrixPresenter gridMatrixPresenter;
        [Inject]
        private IGridInteractor gridClickInteractor;

        // Readonly Properties
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        // Private Properties
        private Vector2Int gridPosition;

        public void OnSpawned(Transform parent, Vector3 position, Vector2Int gridPosition, Vector2 size) {
            SetTransform(parent, position);
            SetGridPosition(gridPosition);
            SetSize(size);
            gridCellMarkView.SetActive(false);
        }

        public void OnDespawned() {
            disposables.Clear();
        }

        private void SetTransform(Transform parent, Vector3 position) {
            transform.SetParent(parent);
            transform.position = position;
        }


        private void SetGridPosition(Vector2Int gridPosition) {
            this.gridPosition = gridPosition;
            gameObject.name = $"Cell ({gridPosition.x},{gridPosition.y})";

            gridMatrixPresenter.GridMatrix
                .Subscribe(OnGridChange)
                .AddTo(disposables);
        }

        private void SetSize(Vector2 size) {
            var renderer = GetComponent<SpriteRenderer>();
            var collider = GetComponent<BoxCollider2D>();

            renderer.size = size;
            collider.size = size;
            collider.offset = new Vector2(size.x / 2, -size.y / 2);
            gridCellMarkView.SetImage(renderer.bounds.center, size);
        }

        private void OnGridChange(List<List<bool>> gridMatrix) {
            if (gridMatrix == null) {
                gridCellMarkView.Show(false);
                return;
            }

            bool show = gridMatrix[gridPosition.x][gridPosition.y];
            gridCellMarkView.Show(show);
        }

        public void Click() {
            gridClickInteractor.OnClickCell(gridPosition);
        }
    }
}