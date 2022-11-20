using AutoMapper;
using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Util.ResourceLoader;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Com.Afb.GridGame.Data.Gateway {
    public class GetGridDataGateway : IGateway<GridDto> {
        // Readonly Properties
        private readonly ILoadFromResources loadFromResources;
        private readonly IMapper dataMapper;

        // Constructor
        public GetGridDataGateway(ILoadFromResources loadFromResources,
                [Inject(Id = "DataMapper")] IMapper dataMapper) {

            this.loadFromResources = loadFromResources;
            this.dataMapper = dataMapper;
        }

        // Public Properties
        public async UniTask<GridDto> Handle() {
            var gridSettings = await loadFromResources.Load<GridSettings>("GridSettings");
            return dataMapper.Map<GridDto>(gridSettings);
        }
    }
}
