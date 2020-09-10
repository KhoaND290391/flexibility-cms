using System.Threading.Tasks;
using FlexCMS.Configuration.Dto;

namespace FlexCMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
