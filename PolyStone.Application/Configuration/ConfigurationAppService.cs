using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using PolyStone.Configuration.Dto;

namespace PolyStone.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PolyStoneAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
