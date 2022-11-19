using Com.Afb.GridGame.Presentation.Interactor;
using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class InteractorInstaller : Installer {
        public override void InstallBindings() {
            BindGridInteractor();
        }

        private void BindGridInteractor() {
            Container.BindInterfacesTo<GridInteractor>()
                .AsSingle()
                .Lazy();
        }
    }
}

