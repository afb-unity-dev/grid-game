using Com.Afb.GridGame.Presentation.View;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class PoolInstaller : MonoInstaller {
        // Public Methods
        public override void InstallBindings() {
            BindGridCellPool();
        }

        // Private Methods
        private void BindGridCellPool() {
            Container.Bind<MonoPoolableMemoryPool<Transform, Vector3, Vector2Int, Vector2, GridCellView>>()
                .FromNew()
                .AsCached()
                .WithArguments(
                    new MemoryPoolSettings(
                        // Initial size
                        16,
                        // Max size
                        int.MaxValue,
                        PoolExpandMethods.Double)
                );
        }
    }
}
