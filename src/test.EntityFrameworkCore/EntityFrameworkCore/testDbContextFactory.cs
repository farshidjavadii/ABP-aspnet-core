using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using test.Configuration;
using test.Web;

namespace test.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class testDbContextFactory : IDesignTimeDbContextFactory<testDbContext>
    {
        public testDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<testDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            testDbContextConfigurer.Configure(builder, configuration.GetConnectionString(testConsts.ConnectionStringName));

            return new testDbContext(builder.Options);
        }
    }
}
