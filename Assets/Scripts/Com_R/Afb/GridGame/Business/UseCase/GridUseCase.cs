using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Data.Gateway;
using UniRx;
using Zenject;
using AutoMapper;
using Cysharp.Threading.Tasks;

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
            gridModel.Value = model;
        }
    }
}