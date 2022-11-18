using AutoMapper;
using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Util.ResourceLoader;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Com.Afb.GridGame.Data.Gateway {
    public class GetGridDataGateway : IGateway<GridDto> {

        [Inject]
        private ILoadFromResources loadFromResources;
        [Inject(Id ="DataMapper")]
        private IMapper dataMapper;

        public async UniTask<GridDto> Handle() {
            var gridSettings = await loadFromResources.Load<GridSettings>("GridSettings");
            return dataMapper.Map<GridDto>(gridSettings);
        }
    }
}
