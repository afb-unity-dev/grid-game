using Com.Afb.GridGame.Presentation.Presenter;
using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class PresentaterInstaller : Installer {
        // Public Methods
        public override void InstallBindings() {
            BindGridPresenter();
        }

        // Private Methods
        private void BindGridPresenter() {
            Container.BindInterfacesTo<GridPresenter>()
                .AsSingle()
                .Lazy();
        }
    }
}
