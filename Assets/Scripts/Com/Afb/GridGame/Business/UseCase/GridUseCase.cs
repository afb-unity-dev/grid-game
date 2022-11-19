using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Data.Gateway;
using UniRx;
using Zenject;
using AutoMapper;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

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

        private async void InitializeGrid() {
            await GetGridModel();
        }

        private async UniTask GetGridModel() {
            var dto = await gridDtoGateway.Handle();
            var model = businessMapper.Map<GridModel>(dto);
            SetGridMatrix(model);
            gridModel.Value = model;
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

        public void MarkCell(int x, int y) {
            var model = gridModel.Value;

            if (!model.GridMatrix[x][y]) {
                model.GridMatrix[x][y] = true;
            }

            gridModel.SetValueAndForceNotify(model);
        }
    }
}