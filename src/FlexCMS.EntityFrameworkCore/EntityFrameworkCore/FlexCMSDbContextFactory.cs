using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FlexCMS.Configuration;
using FlexCMS.Web;

namespace FlexCMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FlexCMSDbContextFactory : IDesignTimeDbContextFactory<FlexCMSDbContext>
    {
        public FlexCMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FlexCMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FlexCMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FlexCMSConsts.ConnectionStringName));

            return new FlexCMSDbContext(builder.Options);
        }
    }
}
