using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Com.Afb.GridGame.Util.ResourceLoader {
    public class IResourceLoader : ILoadFromResources {
        async UniTask<T> ILoadFromResources.Load<T>(string path) {
            return (T) await Resources.LoadAsync<T>(path);
        }
    }
}