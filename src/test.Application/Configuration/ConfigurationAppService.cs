using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using test.Configuration.Dto;

namespace test.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : testAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
