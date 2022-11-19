using Com.Afb.GridGame.Presentation.Presenter;
using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class PresentaterInstaller : Installer {
        public override void InstallBindings() {
            BindGridPresenter();
        }

        private void BindGridPresenter() {
            Container.BindInterfacesTo<GridPresenter>()
                .AsSingle()
                .Lazy();
        }
    }
}
