using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FlexCMS.Configuration.Dto;

namespace FlexCMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FlexCMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
