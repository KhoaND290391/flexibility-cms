using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FlexCMS.Authorization;
using FlexCMS.Configuration.CustomMenu;

namespace FlexCMS
{
    [DependsOn(
        typeof(FlexCMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FlexCMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FlexCMSAuthorizationProvider>();
            //Configuration.Navigation.Providers.Add<CustomNavigationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FlexCMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
