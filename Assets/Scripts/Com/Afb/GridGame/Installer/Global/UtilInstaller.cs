using Com.Afb.GridGame.Util.ResourceLoader;
using Zenject;

namespace Com.Afb.GridGame.Installer.Global {
    public class UtilInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindResourceLoader();
        }

        private void BindResourceLoader() {
            Container.BindInterfacesTo<IResourceLoader>()
                .FromNew()
                .AsTransient()
                .Lazy();
        }
    }
}
