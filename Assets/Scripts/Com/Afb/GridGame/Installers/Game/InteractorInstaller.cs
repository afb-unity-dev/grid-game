using Com.Afb.GridGame.Presentation.Interactor;
using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class InteractorInstaller : Installer {
        // Public Methods
        public override void InstallBindings() {
            BindGridInteractor();
        }

        // Private Methods
        private void BindGridInteractor() {
            Container.BindInterfacesTo<GridInteractor>()
                .AsSingle()
                .Lazy();
        }
    }
}

