using Cysharp.Threading.Tasks;

namespace Com.Afb.GridGame.Data.Gateway {
    public interface IGateway<TDto> {
        // Methods
        UniTask<TDto> Handle();
    }
}

