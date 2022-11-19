using Com.Afb.GridGame.Presentation.Presenter;
using UniRx;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Presentation.View {
    public class GridCellView : MonoBehaviour, IPoolable<Transform, Vector3, Vector2Int, Vector2> {
        // Serialize Fields
        [SerializeField]
        private SpriteRenderer xObject;

        // Dependencies
        [Inject]
        private IGridMatrixPresenter gridMatrixPresenter;

        // Readonly Properties
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        // Private Properties
        private SpriteRenderer spriteRenderer;
        private SpriteRenderer SpriteRenderer {
            get {
                if (spriteRenderer == null) {
                    spriteRenderer = GetComponent<SpriteRenderer>();
                }
                return spriteRenderer;
            }
        }

        public void OnSpawned(Transform parent, Vector3 position, Vector2Int gridPosition, Vector2 size) {
            SetTransform(parent, position);
            SetGridPosition(gridPosition);
            SetSize(size);
        }

        public void OnDespawned() {
            disposables.Clear();
        }

        private void SetTransform(Transform parent, Vector3 position) {
            transform.SetParent(parent);
            transform.position = position;
        }


        private void SetGridPosition(Vector2Int gridPosition) {
            gameObject.name = $"Cell ({gridPosition.x},{gridPosition.y})";
            gridMatrixPresenter.GridMatrix[gridPosition.x][gridPosition.y]
                .Subscribe(OnCellChange)
                .AddTo(disposables);
        }

        private void SetSize(Vector2 size) {
            SpriteRenderer.size = size;
            xObject.size = size;
        }

        private void OnCellChange(bool show) {
            xObject.gameObject.SetActive(show);
        }
    }
}