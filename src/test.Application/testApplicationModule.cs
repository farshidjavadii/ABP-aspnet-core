using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using test.Authorization;

namespace test
{
    [DependsOn(
        typeof(testCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class testApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<testAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(testApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
