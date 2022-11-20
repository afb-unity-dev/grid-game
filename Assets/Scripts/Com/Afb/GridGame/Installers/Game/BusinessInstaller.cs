using AutoMapper;
using Com.Afb.GridGame.Business.UseCase;
using Com.Afb.GridGame.Data.Dto;
using Zenject;

namespace Com.Afb.GridGame.Installers.Game {
    public class BusinessInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindMapper();
            BindGridUseCase();
        }

        private void BindMapper() {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<GridDto, GridModel>()
                    .ForMember(model => model.GridMatrix, opt => opt.Ignore())
                    .ForMember(model => model.Count, opt => opt.Ignore()); ;
            });

            // only during development, validate your mappings; remove it before release
#if UNITY_EDITOR
            configuration.AssertConfigurationIsValid();
#endif
            var mapper = configuration.CreateMapper();

            Container.Bind<IMapper>()
                .WithId("BusinessMapper")
                .FromInstance(mapper);
        }

        private void BindGridUseCase() {
            Container.BindInterfacesTo<GridUseCase>()
                .AsSingle()
                .Lazy();
        }
    }
}
