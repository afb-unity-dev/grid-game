using Com.Afb.GridGame.Util.ResourceLoader;
using Zenject;

namespace Com.Afb.GridGame.Installers.Global {
    public class UtilInstaller : MonoInstaller {
        // Public Methods
        public override void InstallBindings() {
            BindResourceLoader();
        }

        // Private Methods
        private void BindResourceLoader() {
            Container.BindInterfacesTo<ResourceLoader>()
                .FromNew()
                .AsTransient()
                .Lazy();
        }
    }
}
