using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class PresentationInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindPresenter();
            BindInteractor();
        }

        private void BindPresenter() {
            Container.Install<PresentaterInstaller>();
        }

        private void BindInteractor() {
            Container.Install<InteractorInstaller>();
        }
    }
}