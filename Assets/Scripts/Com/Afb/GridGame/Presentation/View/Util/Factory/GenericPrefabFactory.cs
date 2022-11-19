using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Presentation.View.Util.Factory {
    public class GenericPrefabFactory<TValue> : IFactory<TValue>, IFactory<Transform, TValue> {
        // Dependencies
        [Inject]
        private DiContainer container;

        // Private Properties
        private GameObject prefab;
        private Transform parent;

        public GenericPrefabFactory(GameObject prefab, Transform parent = null) {
            this.prefab = prefab;
            this.parent = parent;
        }

        public TValue Create() {
            TValue view = container.InstantiatePrefabForComponent<TValue>(prefab, parent);
            return view;
        }

        public TValue Create(Transform parent) {
            TValue view = container.InstantiatePrefabForComponent<TValue>(prefab, parent);
            return view;
        }
    }
}

