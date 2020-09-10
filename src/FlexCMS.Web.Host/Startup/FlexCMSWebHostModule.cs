using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FlexCMS.Configuration;

namespace FlexCMS.Web.Host.Startup
{
    [DependsOn(
       typeof(FlexCMSWebCoreModule))]
    public class FlexCMSWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FlexCMSWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FlexCMSWebHostModule).GetAssembly());
        }
    }
}
