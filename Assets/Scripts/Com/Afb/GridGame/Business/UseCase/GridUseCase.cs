using System.Collections.Generic;
using AutoMapper;
using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Data.Gateway;
using Com.Afb.GridGame.Util;
using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;

namespace Com.Afb.GridGame.Business.UseCase {
    public class GridUseCase : IGridUseCase {
        // Readonly Properties
        private readonly IGateway<GridDto> gridDtoGateway;
        private readonly IMapper businessMapper;
        private readonly ReactiveProperty<GridModel> gridModel = new ReactiveProperty<GridModel>(null);

        // Public Properties
        public IReadOnlyReactiveProperty<GridModel> GridModel => gridModel;

        public GridUseCase(IGateway<GridDto> gridDtoGateway, [Inject(Id = "BusinessMapper")] IMapper businessMapper) {
            this.gridDtoGateway = gridDtoGateway;
            this.businessMapper = businessMapper;
            InitializeGrid();
        }

        private async void InitializeGrid(int? gridSize = null) {
            GridModel model;
            if (!gridSize.HasValue) {
                model = await GetGridModel();
            }
            else {
                model = new GridModel() {
                    GridSize = gridSize.Value
                };
            }
            
            SetGridMatrix(model);
            ResetCount(model);
            gridModel.Value = model;
        }

        private async UniTask<GridModel> GetGridModel() {
            var dto = await gridDtoGateway.Handle();
            return businessMapper.Map<GridModel>(dto);
        }

        private void ResetCount(GridModel model) {
            model.Count = 0;
        }

        private void SetGridMatrix(GridModel model) {
            int gridSize = model.GridSize;
            model.GridMatrix = new List<List<bool>>();
            for (int x = 0; x < gridSize; x++) {
                var horizontal = new List<bool>();
                model.GridMatrix.Add(horizontal);

                for (int y = 0; y < gridSize; y++) {
                    model.GridMatrix[x].Add(false);
                }
            }
        }

        private bool CheckCell((int x, int y) point) {
            var model = gridModel.Value;

            List<List<bool>> visitMatrix = new List<List<bool>>();
            for (int x = 0; x < model.GridSize; x++) {
                var horizontal = new List<bool>();
                visitMatrix.Add(horizontal);

                for (int y = 0; y < model.GridSize; y++) {
                    visitMatrix[x].Add(false);
                }
            }

            var list = CheckCellRecursive(model, visitMatrix, point);

            bool isMatch = list.Count >= Constants.MATCH_NUMBER;

            if (isMatch) {
                model.Count += list.Count;
                foreach (var pt in list) {
                    model.GridMatrix[pt.x][pt.y] = false;
                }
            }

            return isMatch;
        }

        private List<(int x, int y)> CheckCellRecursive(GridModel model, List<List<bool>> visitMatrix, (int x, int y) point) {
            var list = new List<(int x, int y)>();

            // If point is out of bounds
            if (point.x < 0 || point.y < 0 || point.x >= model.GridSize || point.y >= model.GridSize) {
                return list;
            }

            // If visited do not proceed
            if (visitMatrix[point.x][point.y]) {
                return list;
            }

            // If point is marked
            if (model.GridMatrix[point.x][point.y]) {
                list.Add(point);
                visitMatrix[point.x][point.y] = true;
            }
            else {
                return list;
            }

            // Left
            list.AddRange(CheckCellRecursive(model, visitMatrix, (point.x - 1, point.y)));
            // Right
            list.AddRange(CheckCellRecursive(model, visitMatrix, (point.x + 1, point.y)));
            // Bottom
            list.AddRange(CheckCellRecursive(model, visitMatrix, (point.x, point.y - 1)));
            // Top
            list.AddRange(CheckCellRecursive(model, visitMatrix, (point.x, point.y + 1)));

            return list;
        }

        public void MarkCell((int x, int y) point) {
            var model = gridModel.Value;

            // If point not market
            if (!model.GridMatrix[point.x][point.y]) {
                model.GridMatrix[point.x][point.y] = true;
                gridModel.SetValueAndForceNotify(model);

                if (CheckCell(point)) {
                    gridModel.SetValueAndForceNotify(model);
                }
            }
        }

        public void SetGridSize(int gridSize) {
            InitializeGrid(gridSize);
        }
    }
}