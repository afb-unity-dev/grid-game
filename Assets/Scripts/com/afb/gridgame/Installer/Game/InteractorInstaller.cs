using Com.Afb.GridGame.Presentation.Interactor;
using Zenject;

public class InteractorInstaller : Installer {
    public override void InstallBindings() {
        BindGridInteractor();
    }

    private void BindGridInteractor() {
        Container.BindInterfacesTo<GridInteractor>()
            .AsTransient()
            .Lazy();
    }
}

