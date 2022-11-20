using Com.Afb.GridGame.Presentation.View.Util.InputHelper;
using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class ViewInstaller : Installer {
        // Public Methods
        public override void InstallBindings() {
            BindInputHelper();
        }

        // Private Methods
        private void BindInputHelper() {
            Container.BindInterfacesTo<InputHelper>()
                .AsSingle()
                .Lazy();
        }
    }
}
