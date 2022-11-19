using Cysharp.Threading.Tasks;

namespace Com.Afb.GridGame.Data.Gateway {
    public interface IGateway<TDto> {
        UniTask<TDto> Handle();
    }

    public interface IGateway<TDto, T1> {
        UniTask<TDto> Handle(T1 param1);
    }

    public interface IGateway<TDto, T1, T2> {
        UniTask<TDto> Handle(T1 param1, T2 param2);
    }
}

