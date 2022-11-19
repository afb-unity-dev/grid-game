using System.Collections.Generic;
using Com.Afb.GridGame.Presentation.Interactor;
using UniRx;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Presentation.View {
    public class GridView : MonoBehaviour {
        // Serialize Fields
        [SerializeField]
        private GridContent gridContent;

        // Dependencies
        [Inject]
        private IGridInteractor gridInteractor;
        // Dependencies
        [Inject]
        private MonoPoolableMemoryPool<Transform, Vector3, Vector2Int, Vector2, GridCellView> gridCellPool;

        // Readonly Properties
        private readonly List<GridCellView> gridCells = new List<GridCellView>();

        private void Start() {
            Initiaize();
        }

        private void Initiaize() {
            gridInteractor.GridSizePresenter.GridSize
                .Subscribe(OnGridSizeUpdate);
        }

        private void OnGridSizeUpdate(int gridSize) {
            Debug.Log("GridView - GridSize: " + gridSize);
            ClearGrid();
            CreateGrid(gridSize);
        }

        private void ClearGrid() {
            foreach (var cell in gridCells) {
                gridCellPool.Despawn(cell);
            }
            gridCells.Clear();
        }

        private void CreateGrid(int gridSize) {
            if (gridSize == 0) {
                return;
            }

            Bounds bounds = gridContent.Bounds;
            Vector2 cellSize = new Vector2(bounds.size.x / gridSize,
                bounds.size.y / gridSize);
            Vector2 origin = new Vector2(bounds.min.x, bounds.max.y);

            for (int x = 0; x < gridSize; x++) {
                for (int y = 0; y < gridSize; y++) {
                    Vector2Int gridPosition = new Vector2Int(x, y);
                    var cell = CreateCell(gridPosition, cellSize, origin);
                    gridCells.Add(cell);
                }
            }
        }

        private GridCellView CreateCell(Vector2Int gridPosition, Vector2 cellSize, Vector2 origin) {
            float x = origin.x + gridPosition.x * cellSize.x;
            float y = origin.y - gridPosition.y * cellSize.y;
            Vector3 position = new Vector3(x, y, 0);
            return gridCellPool.Spawn(gridContent.transform, position, gridPosition, cellSize);
    
        }
    }
}
