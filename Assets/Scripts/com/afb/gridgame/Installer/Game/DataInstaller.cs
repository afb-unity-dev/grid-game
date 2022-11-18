using AutoMapper;
using Com.Afb.GridGame.Data.Dto;
using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

    }

    private void BindMapper() {
        var configuration = new MapperConfiguration(cfg => {
            cfg.CreateMap<GridSettings, GridDto>();
        });

        // only during development, validate your mappings; remove it before release
#if DEBUG
        configuration.AssertConfigurationIsValid();
#endif
        // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
        var mapper = configuration.CreateMapper();

        Container.Bind<IMapper>().WithId("DataMapper").FromInstance(mapper).AsSingle();
    }
}