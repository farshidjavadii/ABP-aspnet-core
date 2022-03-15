using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using test.EntityFrameworkCore;
using test.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace test.Web.Tests
{
    [DependsOn(
        typeof(testWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class testWebTestModule : AbpModule
    {
        public testWebTestModule(testEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(testWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(testWebMvcModule).Assembly);
        }
    }
}