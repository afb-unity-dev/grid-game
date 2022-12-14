using Com.Afb.GridGame.Presentation.View;
using Com.Afb.GridGame.Presentation.View.Util.Factory;
using UnityEngine;
using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class FactoryInstaller : MonoInstaller {
        // Serialize Fields
        [Header("Grid Cell")]
        [SerializeField]
        private GameObject gridCellPrefab;
        [SerializeField]
        private Transform defaultgridCellParent;

        // Public Methods
        public override void InstallBindings() {
            BindGridCellFactory();
        }

        // Private Methods
        private void BindGridCellFactory() {
            Container.BindInterfacesTo<GenericPrefabFactory<GridCellView>>()
                .FromNew()
                .AsSingle()
                .WithArguments(gridCellPrefab, defaultgridCellParent)
                .Lazy();
        }
    }
}
