using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Util.ResourceLoader;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Com.Afb.GridGame.Data.Gateway {
    public class GetGridDataGateway : IGateway<GridDto> {

        [Inject]
        private ILoadFromResources loadFromResources;


        public async UniTask<GridDto> Handle() {
            var gridSettings = await loadFromResources.Load<GridSettings>("GridSettings");


            return null ;
        }
    }
}
