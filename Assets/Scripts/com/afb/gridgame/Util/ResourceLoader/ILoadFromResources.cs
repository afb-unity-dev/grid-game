using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Com.Afb.GridGame.Util.ResourceLoader {
    public interface ILoadFromResources {
        public UniTask<T> Load<T>(string path) where T : Object;
    }
}