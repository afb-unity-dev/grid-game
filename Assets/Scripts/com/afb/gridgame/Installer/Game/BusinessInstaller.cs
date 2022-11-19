using AutoMapper;
using Com.Afb.GridGame.Business.UseCase;
using Com.Afb.GridGame.Data.Dto;
using Zenject;

public class BusinessInstaller : MonoInstaller {
    public override void InstallBindings() {
        BindMapper();
        BindGridUseCase();
    }

    private void BindMapper() {
        var configuration = new MapperConfiguration(cfg => {
            cfg.CreateMap<GridDto, GridModel>();
        });

        // only during development, validate your mappings; remove it before release
#if DEBUG
        configuration.AssertConfigurationIsValid();
#endif
        var mapper = configuration.CreateMapper();

        Container.Bind<IMapper>()
            .WithId("BusinessMapper")
            .FromInstance(mapper);
    }

    private void BindGridUseCase() {
        Container.BindInterfacesTo<GridUseCase>()
            .AsTransient()
            .Lazy();
    }
}
