using AutoMapper;
using Com.Afb.GridGame.Data.Dto;
using Com.Afb.GridGame.Data.Gateway;
using Zenject;

public class DataInstaller : MonoInstaller {
    public override void InstallBindings() {
        BindMapper();
        BindGetGridDataGateway();
    }

    private void BindMapper() {
        var configuration = new MapperConfiguration(cfg => {
            cfg.CreateMap<GridSettings, GridDto>();
        });

        // only during development, validate your mappings; remove it before release
#if DEBUG
        configuration.AssertConfigurationIsValid();
#endif
        var mapper = configuration.CreateMapper();

        Container.Bind<IMapper>()
            .WithId("DataMapper")
            .FromInstance(mapper);
    }

    private void BindGetGridDataGateway() {
        Container.BindInterfacesTo<GetGridDataGateway>()
            .AsTransient()
            .Lazy();
    }
}