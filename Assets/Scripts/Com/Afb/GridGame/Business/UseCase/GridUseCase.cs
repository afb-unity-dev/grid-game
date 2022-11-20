using AutoMapper;
using Com.Afb.GridGame.Business.Util;
using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Data.Gateway;
using Com.Afb.GridGame.Data.Model;
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

        // Constructor
        public GridUseCase(IGateway<GridDto> gridDtoGateway,
                [Inject(Id = "BusinessMapper")] IMapper businessMapper) {

            this.gridDtoGateway = gridDtoGateway;
            this.businessMapper = businessMapper;
            InitializeGrid();
        }

        // Public Methods
        public void MarkCell((int x, int y) point) {
            var model = gridModel.Value;

            // If point not market
            if (!model.GridMatrix[point.x][point.y]) {
                model.GridMatrix[point.x][point.y] = true;
                gridModel.SetValueAndForceNotify(model);

                if (CheckGrid.CheckCellNeighbors(model, point)) {
                    gridModel.SetValueAndForceNotify(model);
                }
            }
        }

        public void SetGridSize(int gridSize) {
            InitializeGrid(gridSize);
        }

        // Private Methods
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

            CreateGridMatrix.Create(model);
            model.Count = 0;
            gridModel.Value = model;
        }

        private async UniTask<GridModel> GetGridModel() {
            var dto = await gridDtoGateway.Handle();
            return businessMapper.Map<GridModel>(dto);
        }
    }
}