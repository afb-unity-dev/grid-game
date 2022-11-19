using Com.Afb.GridGame.Presentation.Presenter;
using Zenject;

public class PresentaterInstaller : Installer {
    public override void InstallBindings() {

        BindGridPresenter();
    }

    private void BindGridPresenter() {
        Container.BindInterfacesTo<GridPresenter>()
            .AsTransient()
            .Lazy();
    }
}
