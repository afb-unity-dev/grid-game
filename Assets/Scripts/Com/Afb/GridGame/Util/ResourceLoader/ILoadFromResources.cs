using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Com.Afb.GridGame.Util.ResourceLoader {
    public interface ILoadFromResources {
        // Methods
        UniTask<T> Load<T>(string path) where T : Object;
    }
}